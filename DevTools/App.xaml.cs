using Prism.Ioc;
using DevTools.Views;
using System.Windows;
using DevTools.Modules.CodeLibrary;
using DevTools.Modules.ColorTableMod;
using Prism.Modularity;
using DevTools.Services.Interfaces;
using DevTools.Services;

namespace DevTools
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
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CodeLibraryModule>();
            moduleCatalog.AddModule<ColorTableModModule>();

        }
    }
}
