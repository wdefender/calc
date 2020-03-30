using Prism.Ioc;
using calc.DesktopClient.Views;
using System.Windows;
using Prism.Modularity;
using calc.UI.Keys;
using calc.UI.Display;
using calc.UI.Toolbar;
using calc.Common.Infrastructure.Interfaces;
using calc.Common.Services;

namespace calc.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IInputService, InputService>();
            containerRegistry.RegisterSingleton<IOutputService, OutputService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule(typeof(KeysModule), InitializationMode.WhenAvailable);
            moduleCatalog.AddModule(typeof(DisplayModule), InitializationMode.WhenAvailable);
            moduleCatalog.AddModule(typeof(ToolbarModule), InitializationMode.WhenAvailable);
        }
    }
}
