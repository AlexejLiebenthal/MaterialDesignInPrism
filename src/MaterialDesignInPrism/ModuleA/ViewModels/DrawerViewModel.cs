using MaterialDesignThemes.Wpf;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignInPrism.ModuleA.ViewModels
{
    public class DrawerViewModel
    {
        public DelegateCommand SnackCommand { get; }
        public DrawerViewModel(ISnackbarMessageQueue messageQueue)
        {
            SnackCommand = new DelegateCommand(() =>
            {
                messageQueue.Enqueue("Test");
                messageQueue.Enqueue("Test Action", "Action", () => { });
            });
        }
    }
}
