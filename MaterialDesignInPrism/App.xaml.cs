using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignInPrism.Views;
using Prism.Ioc;

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
