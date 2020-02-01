namespace FoxAgent.Hardware
{
    public class LinuxHardwareInfoFactory : IHardwareInfoFactory
    {
        public CPUInfo GetCPUInfo()
        {
            return new LinuxCPUInfo();
        }
    }
}