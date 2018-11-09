using Plugin.Settings.Abstractions;
using Prism.Logging.Syslog;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SoCalCodeCamp.LoggingDemo.Services
{
    public class SyslogOptions : IEditableSyslogOptions, ISyslogOptions, INotifyPropertyChanged
    {
        private ISettings _settings { get; }

        public SyslogOptions(ISettings settings) => _settings = settings;

        public string HostNameOrIp
        {
            get => _settings.GetValueOrDefault(nameof(HostNameOrIp), "192.168.1.10");
            set
            {
                if (_settings.AddOrUpdateValue(nameof(HostNameOrIp), value))
                    RaisePropertyChanged();
            }
        }
        public int? Port
        {
            get => _settings.GetValueOrDefault(nameof(Port), 514);
            set
            {
                if (value < 0 || value > 65535) return;
                if (_settings.AddOrUpdateValue(nameof(Port), (int)value))
                    RaisePropertyChanged();
            }
        }
        public string AppNameOrTag
        {
            get => _settings.GetValueOrDefault(nameof(AppNameOrTag), "DemoApp");
            set
            {
                if (_settings.AddOrUpdateValue(nameof(AppNameOrTag), value))
                    RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
