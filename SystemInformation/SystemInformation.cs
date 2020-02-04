using System.Runtime.InteropServices;

using FoxAgent.Core;

namespace FoxAgent.SystemInformation
{
    public class SysInfo
    {
        public static ISystemInformationFactory GetFactory()
        {
        #if Windows
        #elif Linux
            return new LinuxSystemInformationFactory();
        #endif

            return null;
        }
    }
}