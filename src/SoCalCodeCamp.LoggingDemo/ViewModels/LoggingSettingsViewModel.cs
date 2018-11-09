using Prism.Mvvm;
using SoCalCodeCamp.LoggingDemo.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoCalCodeCamp.LoggingDemo.ViewModels
{
    public class LoggingSettingsViewModel : BindableBase
    {
        public LoggingSettingsViewModel(IEditableSyslogOptions options)
        {
            Options = options;
        }

        public IEditableSyslogOptions Options { get; }
    }
}
