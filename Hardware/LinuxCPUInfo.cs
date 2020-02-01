using System;
using System.IO;
using System.Collections.Generic;
using FoxAgent.Parse;

namespace FoxAgent.Hardware
{
    public class LinuxCPUInfo : CPUInfo
    {
        public LinuxCPUInfo()
        {
            string[] cpuInfoLines = File.ReadAllLines(@"/proc/cpuinfo");

            Dictionary<string, string> CPUInformation = new Dictionary<string,string>();

            Array.ForEach(cpuInfoLines, item => {
                RegexKeyValue parameter = new RegexKeyValue(item);

                if(parameter.Key != null && !CPUInformation.ContainsKey(parameter.Key.ToLower()))
                {
                    CPUInformation.Add(parameter.Key.ToLower(), parameter.Value);
                }
            });

            ModelName = CPUInformation.GetValueOrDefault("model name");
        }
    }
}