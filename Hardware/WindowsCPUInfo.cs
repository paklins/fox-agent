using System;
using System.Collections.Generic;
using System.Linq;
#if Windows 
using System.Management;
#endif
using Microsoft.Win32;

namespace FoxAgent.Hardware
{
    public class WindowsCPUInfo : CPUInfo
    {
        #if Windows
        private Dictionary<CPUCacheLevel, uint> CacheSizes()
        {
            Dictionary<CPUCacheLevel, uint> cacheSizes = new Dictionary<CPUCacheLevel, uint>();

            ManagementClass management = new ManagementClass("Win32_CacheMemory");
            ManagementObjectCollection collection = management.GetInstances();
            
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                PropertyDataCollection properties = enumerator.Current.Properties;

                CPUCacheLevel level = (CPUCacheLevel)((ushort)properties["Level"].Value);
                uint size = (uint)properties["MaxCacheSize"].Value;

                cacheSizes.Add(level, size);
            }

            return cacheSizes;
        }

        public WindowsCPUInfo()
        {
            var key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0\");
            ModelName = key.GetValue("ProcessorNameString").ToString();
            Identifier = key.GetValue("Identifier").ToString();
            MHz = Double.Parse(key.GetValue("~MHz").ToString());

            cacheSizes = CacheSizes();
        }
        #endif
    }
}