using MaterialDesignInPrism.Windows;
using Prism.Regions;
using System.Windows;

namespace MaterialDesignInPrism.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        private readonly IRegionManager regionManager;

        public Shell(IRegionManager regionManager)
        {
            this.regionManager = regionManager ?? throw new System.ArgumentNullException(nameof(regionManager));

            MaterialDesignWindow.RegisterCommands(this);
            InitializeComponent();

            InitializeDrawerRegion();
            InitializeDialogRegion();
        }

        private void InitializeDrawerRegion()
        {
            RegionManager.SetRegionName(DrawerContent, "DrawerContent");
            RegionManager.SetRegionManager(DrawerContent, regionManager);
        }
        private void InitializeDialogRegion()
        {
            RegionManager.SetRegionName(DialogContent, "DialogContent");
            RegionManager.SetRegionManager(DialogContent, regionManager);
        }
    }
}
