using Prism.Ioc;
using Prism.Modularity;
using SoCalCodeCamp.LoggingDemo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SoCalCodeCamp.Sample
{
    public partial class App
    {
        public App() : base() { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            var result = await NavigationService.NavigateAsync("NavigationPage/LoggingSettingsPage");
            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<LoggingModule>();
        }
    }
}
