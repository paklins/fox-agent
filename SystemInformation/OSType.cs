using System.ComponentModel;

namespace FoxAgent.SystemInformation
{
    public enum OSType
    {
        [Description("Microsoft Windows")]
        Windows,
        Linux,
        [Description("Apple MacOS X")]
        MacOS,
        FreeBSD
    }
}