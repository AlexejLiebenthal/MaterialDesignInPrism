using Prism.Services.Dialogs;
using System.Threading.Tasks;

namespace MaterialDesignInPrism.ModuleA.ViewModels
{
    public class DialogViewModel : DialogViewModelBase
    {
        private static readonly string TextTemplate = "Hello, {0}!";
        private IDialogParameters dialogParameters;

        private string text = string.Format(TextTemplate, "World");
        public string Text
        {
            get => text;
            private set => SetProperty(ref text, value);
        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            dialogParameters = parameters;

            await Task.Delay(1000);

            Text = string.Format(TextTemplate, dialogParameters.GetValue<string>("name"));
        }

        protected override void CloseDialog(string parameter)
        {
            RaiseRequestClose(new DialogResult(true, dialogParameters));
        }
    }
}
