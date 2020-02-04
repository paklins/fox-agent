using FoxAgent.SystemInformation;

namespace FoxAgent.Hardware
{
    public class HardwareInfo
    {
        public static IHardwareInfoFactory GetFactory()
        {
            #if Windows
                return new WindowsHardwareInfoFactory();
            #elif Linux
                return new LinuxHardwareInfoFactory();
            #endif

            return null;
        }
    }
}