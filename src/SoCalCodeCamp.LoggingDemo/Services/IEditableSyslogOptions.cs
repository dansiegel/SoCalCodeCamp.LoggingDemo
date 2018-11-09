namespace SoCalCodeCamp.LoggingDemo.Services
{
    public interface IEditableSyslogOptions
    {
        string HostNameOrIp { get; set; }
        int? Port { get; set; }
        string AppNameOrTag { get; set; }
    }
}
