using System.Runtime.InteropServices;

using FoxAgent.Core;

namespace FoxAgent.SystemInformation
{
    public class SysInfo
    {
        public string OSName { get ; private set; }
        public OSType Type { get; private set;}
        public string Platform {get; private set; }

        public SysInfo()
        {
            OSName = RuntimeInformation.OSDescription;

            fillOSType();
        }

        private void fillOSType()
        {
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Type = OSType.Windows;
            }
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Type = OSType.Linux;
            }
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Type = OSType.MacOS;
            }
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
            {
                Type = OSType.FreeBSD;
            }

            Platform = Type.GetDescription();
        }
    }
}