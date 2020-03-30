﻿using calc.UI.Keys.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace calc.UI.Keys
{
    public class KeysModule : IModule
    {
        private readonly IRegionManager regionManager;

        public KeysModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.Regions["KeysRegion"].Add(containerProvider.Resolve<KeysView>()); ;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}