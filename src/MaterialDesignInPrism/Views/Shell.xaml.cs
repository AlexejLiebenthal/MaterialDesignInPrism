using Prism.Regions;

namespace MaterialDesignInPrism.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell 
    {
        private readonly IRegionManager regionManager;

        public Shell(IRegionManager regionManager)
        {
            this.regionManager = regionManager ?? throw new System.ArgumentNullException(nameof(regionManager));

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
