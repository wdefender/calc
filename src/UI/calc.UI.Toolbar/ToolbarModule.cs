using calc.Common.Infrastructure.Constants;
using calc.UI.Toolbar.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace calc.UI.Toolbar
{
    public class ToolbarModule : IModule
    {
        private readonly IRegionManager regionManager;

        public ToolbarModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.Regions[RegionNames.ToolbarRegion].Add(containerProvider.Resolve<ToolbarView>()); ;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}