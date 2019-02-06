using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignInPrism.ModuleA.ViewModels
{
    public class MainContentViewModel
    {
        private readonly IRegionManager regionManager;

        public string Text { get; } = "My First Material Design App";

        public DelegateCommand OpenDialogCommand { get; }

        public MainContentViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager ?? throw new ArgumentNullException(nameof(regionManager));

            OpenDialogCommand = new DelegateCommand(OpenDialog);
        }

        private async void OpenDialog()
        {
            var view = regionManager.Regions["DialogContent"].Views.First();
            await DialogHost.Show(view);
        }
    }
}
