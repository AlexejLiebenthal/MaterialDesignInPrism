using MaterialDesignInPrism.Windows;
using System.Windows;

namespace MaterialDesignInPrism.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            MaterialDesignWindow.RegisterCommands(this);
            InitializeComponent();
        }
    }
}
