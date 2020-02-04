using System;
using FoxAgent.Core;
using FoxAgent.Parse;

namespace FoxAgent.Hardware
{
    public class LinuxCPUInfo : CPUInfo
    {
        public LinuxCPUInfo()
        {
            string CPUProductInfo = "lshw -c CPU 2> /dev/null | egrep 'product|vendor|capabilities'".Command();
            string CPUCoresInfo = @"lscpu | egrep '^CPU\(s\)|Thread\(s\) per core|Core\(s\) per socket|CPU MHz|Vendor ID'".Command();
            string CPUCacheInfo = "getconf -a | egrep '[^I]CACHE_SIZE' | awk -F' ' '{ print $1\":\"$2; }'".Command();

            var cpuInfoReaderKV = new KeyValueSetReader();
            cpuInfoReaderKV.read(CPUProductInfo);
            cpuInfoReaderKV.read(CPUCoresInfo);
            cpuInfoReaderKV.read(CPUCacheInfo);

            ModelName = cpuInfoReaderKV.GetValue("Product");
            Stepping = cpuInfoReaderKV.GetIntValue("Stepping");
            MHz = cpuInfoReaderKV.GetDoubleValue("CPU MHz");

            uint cache1Level = (uint)cpuInfoReaderKV.GetIntValue("LEVEL1_DCACHE_SIZE");
            uint cache1Leve2 = (uint)cpuInfoReaderKV.GetIntValue("LEVEL2_CACHE_SIZE");
            uint cache1Leve3 = (uint)cpuInfoReaderKV.GetIntValue("LEVEL3_CACHE_SIZE");

            cacheSizes.Add(CPUCacheLevel.Level1, cache1Level);
            cacheSizes.Add(CPUCacheLevel.Level2, cache1Leve2);
            cacheSizes.Add(CPUCacheLevel.Level3, cache1Leve3);

            Vendor = cpuInfoReaderKV.GetValue("Vendor");
            VendorID = cpuInfoReaderKV.GetValue("Vendor ID");
            Flags = cpuInfoReaderKV.GetValue("Capabilities");
            CPUCount = (uint)cpuInfoReaderKV.GetIntValue("CPU(s)");
            ThreadsPerCore = (uint)cpuInfoReaderKV.GetIntValue("Thread(s) per core");
            CoresPerSocket = (uint)cpuInfoReaderKV.GetIntValue("Core(s) per socket");
        }
    }
}