namespace FoxAgent.SystemInformation
{
    public class LinuxSystemInformationFactory : ISystemInformationFactory
    {
        public LinuxSystemInformation Information()
        {
            return new LinuxSystemInformation();
        }
    }
}