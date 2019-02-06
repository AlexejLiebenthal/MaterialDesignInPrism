using MaterialDesignInPrism.ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace MaterialDesignInPrism.ModuleA
{
    public class AModule : IModule
    {
        private readonly IRegionManager regionManager;

        public AModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager ?? throw new ArgumentNullException(nameof(regionManager));
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.RegisterViewWithRegion("MainContent", typeof(MainContentView));
            regionManager.RegisterViewWithRegion("DrawerContent", typeof(DrawerView));
            regionManager.RegisterViewWithRegion("DialogContent", typeof(DialogView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry) { }
    }
}
