using FoxAgent.SystemInformation;

namespace FoxAgent.Hardware
{
    public interface IHardwareInfoFactory
    {
        CPUInfo GetCPUInfo();
    }
}