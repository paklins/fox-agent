namespace FoxAgent.SystemInformation
{
    public interface ISystemInformation
    {
        OSType Type { get; }
        string Platform { get; }
        string Name { get; }

        string ID { get; }

        string IDLike { get; }
    }
}