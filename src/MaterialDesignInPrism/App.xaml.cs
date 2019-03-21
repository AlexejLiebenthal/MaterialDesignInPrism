using MaterialDesignInPrism.ModuleA;
using MaterialDesignInPrism.Services;
using MaterialDesignInPrism.Views;
using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Services.Dialogs;
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
            containerRegistry.Register<IDialogService, MaterialDialogService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<AModule>();
        }
    }
}
