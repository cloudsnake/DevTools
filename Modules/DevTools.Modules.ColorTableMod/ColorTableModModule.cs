using DevTools.Core;
using DevTools.Modules.ColorTableMod.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace DevTools.Modules.ColorTableMod
{
    public class ColorTableModModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ColorTableModModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //_regionManager.RequestNavigate(RegionNames.ContentRegion, "ColorTable");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ColorTable>();
        }
    }
}