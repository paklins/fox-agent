using System;
using FoxAgent.SystemInformation;
using FoxAgent.Hardware;

namespace FoxAgent
{
    class Program
    {
        static void Main(string[] args)
        {
            SysInfo sysInfo = new SysInfo();

            IHardwareInfoFactory factory = HardwareInfo.GetFactory(sysInfo);
            CPUInfo cpuInfo = factory.GetCPUInfo();

            Console.WriteLine("Operation system: " + sysInfo.OSName);
            Console.WriteLine("Platform:         " + sysInfo.Platform);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("CPU info");
            Console.WriteLine("    - name:         " + cpuInfo.ModelName);
            Console.WriteLine("    - identifier:   " + cpuInfo.Identifier);
            Console.WriteLine("    - MHz:          " + cpuInfo.MHz);
            Console.WriteLine("    - Cache");
            Console.WriteLine("        - level 1:  " + cpuInfo.CacheLevel1);
            Console.WriteLine("        - level 2:  " + cpuInfo.CacheLevel2);
            Console.WriteLine("        - level 3:  " + cpuInfo.CacheLevel3);
        }
    }
}
