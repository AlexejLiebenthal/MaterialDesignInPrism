using MaterialDesignInPrism.ModuleA;
using MaterialDesignInPrism.Views;
using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace MaterialDesignInPrism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell() => Container.Resolve<Shell>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<ISnackbarMessageQueue>(new SnackbarMessageQueue());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<AModule>();
        }
    }
}
