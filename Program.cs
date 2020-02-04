using System;
using FoxAgent.SystemInformation;
using FoxAgent.Hardware;

namespace FoxAgent
{
    class Program
    {
        static void Main(string[] args)
        {
            IHardwareInfoFactory factory = HardwareInfo.GetFactory();
            ISystemInformationFactory systemInformationFactory = SysInfo.GetFactory();

            CPUInfo cpuInfo = factory.GetCPUInfo();
            ISystemInformation sysInfo = systemInformationFactory.Information();

            Console.WriteLine("Operation system: " + sysInfo.Name);
            Console.WriteLine("ID:               " + sysInfo.ID);
            Console.WriteLine("Based on:         " + sysInfo.IDLike);
            Console.WriteLine("Platform:         " + sysInfo.Platform);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("CPU info");
            Console.WriteLine("    - name:               " + cpuInfo.ModelName);
            Console.WriteLine("    - vendor:             " + cpuInfo.Vendor);
            Console.WriteLine("    - vendor id:          " + cpuInfo.VendorID);
            Console.WriteLine("    - CPU(s):             " + cpuInfo.CPUCount);
            Console.WriteLine("    - Thread(s) per core: " + cpuInfo.ThreadsPerCore);
            Console.WriteLine("    - Core(s) per socket: " + cpuInfo.CoresPerSocket);
            // Console.WriteLine("    - identifier:   " + cpuInfo.Identifier);
            Console.WriteLine("    - MHz:                " + cpuInfo.MHz);
            Console.WriteLine("    - Cache");
            Console.WriteLine("        - level 1:  " + cpuInfo.CacheLevel1);
            Console.WriteLine("        - level 2:  " + cpuInfo.CacheLevel2);
            Console.WriteLine("        - level 3:  " + cpuInfo.CacheLevel3);
            Console.WriteLine("    - Flags: " + cpuInfo.Flags);
        }
    }
}
