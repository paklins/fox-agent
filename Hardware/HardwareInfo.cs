using FoxAgent.SystemInformation;

namespace FoxAgent.Hardware
{
    public class HardwareInfo
    {
        public static IHardwareInfoFactory GetFactory(SysInfo sysInfo)
        {
            if(sysInfo.Type.Equals(OSType.Windows))
            {
                return new WindowsHardwareInfoFactory();
            }

            return new LinuxHardwareInfoFactory();
        }
    }
}