namespace FoxAgent.SystemInformation
{
    public interface ISystemInformationFactory
    {
        public ISystemInformation Information()
        {
            #if Linux
                return new LinuxSystemInformation();
            #endif

            return null;
        }
    }
}