namespace FoxAgent.Hardware
{
    public class WindowsHardwareInfoFactory : IHardwareInfoFactory
    {
        public CPUInfo GetCPUInfo()
        {
            return new WindowsCPUInfo();
        }
    }
}