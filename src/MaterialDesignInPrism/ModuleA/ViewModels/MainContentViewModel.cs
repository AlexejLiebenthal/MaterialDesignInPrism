using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;

namespace MaterialDesignInPrism.ModuleA.ViewModels
{
    public class MainContentViewModel
    {
        private readonly IDialogService dialogService;
        private readonly ISnackbarMessageQueue snackbarMessageQueue;

        public string Text { get; } = "My First Material Design App";

        public DelegateCommand OpenDialogCommand { get; }

        public MainContentViewModel(IDialogService dialogService, ISnackbarMessageQueue snackbarMessageQueue)
        {
            this.dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            this.snackbarMessageQueue = snackbarMessageQueue ?? throw new ArgumentNullException(nameof(snackbarMessageQueue));

            OpenDialogCommand = new DelegateCommand(OpenDialog);
        }

        private void OpenDialog()
        {
            dialogService.ShowDialog("DialogView", new DialogParameters("name=Alex"), r => 
            {
                snackbarMessageQueue.Enqueue($"Result is: {r.Result}, 'name' Parameter was '{r.Parameters.GetValue<string>("name")}'");
            });
        }
    }
}
