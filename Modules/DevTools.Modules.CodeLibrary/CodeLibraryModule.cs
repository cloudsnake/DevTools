using DevTools.Core;
using DevTools.Modules.CodeLibrary.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace DevTools.Modules.CodeLibrary
{
    public class CodeLibraryModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public CodeLibraryModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "Code");

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CodeInfo>();
            containerRegistry.RegisterForNavigation<AddUpdateCodeDocument>();

            containerRegistry.RegisterForNavigation<Code>();
        }
    }
}