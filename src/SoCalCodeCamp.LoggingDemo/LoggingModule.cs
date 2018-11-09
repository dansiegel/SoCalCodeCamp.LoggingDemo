using Prism.Ioc;
using Prism.Logging;
using Prism.Logging.Syslog;
using Prism.Modularity;
using System;
using Xamarin.Forms.Xaml;
using Prism.Plugin.Popups;
using SoCalCodeCamp.LoggingDemo.Views;
using SoCalCodeCamp.LoggingDemo.ViewModels;
using SoCalCodeCamp.LoggingDemo.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SoCalCodeCamp.LoggingDemo
{
    public class LoggingModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Create this as a transient service so we can be sure we always get a new instance...
            containerRegistry.Register<ILogger, SyslogLogger>();
            containerRegistry.Register<ILoggerFacade, SyslogLogger>();
            containerRegistry.Register<ISyslogOptions, SyslogOptions>();
            containerRegistry.Register<IEditableSyslogOptions, SyslogOptions>();
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterInstance(Plugin.Settings.CrossSettings.Current);

            // Note that when registering the View/ViewModel you do not need to follow Prism naming conventions
            containerRegistry.RegisterForNavigation<LoggingSettingsPage, LoggingSettingsViewModel>();
            containerRegistry.RegisterForNavigation<TestLogMessengerPage, TestLogMessengerViewModel>();
        }
    }
}
