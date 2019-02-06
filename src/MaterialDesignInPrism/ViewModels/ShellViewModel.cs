using MaterialDesignThemes.Wpf;

namespace MaterialDesignInPrism.ViewModels
{
    public class ShellViewModel
    {
        public string Title { get; } = "Material Design In Prism - App";

        public ISnackbarMessageQueue MessageQueue { get; }

        public ShellViewModel(ISnackbarMessageQueue messageQueue)
        {
            MessageQueue = messageQueue ?? throw new System.ArgumentNullException(nameof(messageQueue));
        }
    }
}
