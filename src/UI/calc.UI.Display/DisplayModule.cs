using calc.UI.Display.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace calc.UI.Display
{
    public class DisplayModule : IModule
    {
        private readonly IRegionManager regionManager;

        public DisplayModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.Regions["DisplayRegion"].Add(containerProvider.Resolve<DisplayView>()); ;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}