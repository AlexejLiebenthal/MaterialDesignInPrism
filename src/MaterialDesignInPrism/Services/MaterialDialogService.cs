using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace MaterialDesignInPrism.Services
{
    public class MaterialDialogService : IDialogService
    {
        private readonly IContainerExtension containerExtension;

        public MaterialDialogService(IContainerExtension containerExtension)
        {
            this.containerExtension = containerExtension ?? throw new ArgumentNullException(nameof(containerExtension));
        }

        public void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback)
        {
            ShowInternal(name, parameters, callback, false);
        }

        public void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback)
        {
            ShowInternal(name, parameters, callback, true);
        }

        private async void ShowInternal(string name, IDialogParameters parameters, Action<IDialogResult> callback, bool isModel)
        {
            var content = containerExtension.Resolve<object>(name);
            if (!(content is FrameworkElement dialogContent))
                throw new NullReferenceException("A dialog's content must be a FrameworkElement");

            if (!(dialogContent.DataContext is IDialogAware viewModel))
                throw new NullReferenceException("A dialog's ViewModel must implement the IDialogAware interface");

            var dialogHost = GetFirstDialogHost(Application.Current.MainWindow);
            dialogHost.CloseOnClickAway = !isModel;
            void CloseRequest(IDialogResult result) => DialogHost.CloseDialogCommand.Execute(result, dialogContent);

            var dialogResult = await DialogHost.Show(
                content: dialogContent,
                dialogIdentifier: dialogHost.Identifier,
                openedEventHandler: (_, __) =>
                {
                    viewModel.RequestClose += CloseRequest;

                    viewModel.OnDialogOpened(parameters);
                },
                closingEventHandler: (_, args) =>
                {
                    if (!viewModel.CanCloseDialog())
                    {
                        args.Cancel();
                        return;
                    }

                    viewModel.RequestClose -= CloseRequest;
                }).ConfigureAwait(false) as IDialogResult;

            viewModel.OnDialogClosed();
            callback?.Invoke(dialogResult ?? new DialogResult());
        }

        private DialogHost GetFirstDialogHost(Window window)
        {
            if (window == null) throw new ArgumentNullException(nameof(window));

            var dialogHost = VisualDepthFirstTraversal(window).OfType<DialogHost>().FirstOrDefault();

            if (dialogHost == null)
                throw new InvalidOperationException("Unable to find a DialogHost in visual tree");

            return dialogHost;

        }
        private IEnumerable<DependencyObject> VisualDepthFirstTraversal(DependencyObject node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            yield return node;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(node); i++)
            {
                var child = VisualTreeHelper.GetChild(node, i);
                foreach (var descendant in VisualDepthFirstTraversal(child))
                {
                    yield return descendant;
                }
            }
        }
    }
}
