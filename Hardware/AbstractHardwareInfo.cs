namespace FoxAgent.Hardware
{
    public abstract class AbstractHardwareInfo
    {
        public string Vendor { get; protected set; }
        public string VendorID { get; protected set; }
        public string Family { get; protected set; }
        public int ModelID { get; protected set; }
        public string ModelName { get; protected set; }
    }
}