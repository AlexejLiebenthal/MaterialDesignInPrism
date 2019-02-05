using MaterialDesignInPrism.Views;
using Prism.Ioc;
using System.Windows;

namespace MaterialDesignInPrism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell() => Container.Resolve<Shell>();
        protected override void RegisterTypes(IContainerRegistry containerRegistry) { }
    }
}
