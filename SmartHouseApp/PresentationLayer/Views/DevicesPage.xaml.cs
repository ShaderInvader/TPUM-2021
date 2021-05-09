using System.Windows.Controls;

namespace ClientPresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for DevicesPage.xaml
    /// </summary>
    public partial class DevicesPage : Page
    {
        private ViewModels.DeviceViewModel DeviceViewModel { get; set; } = new ViewModels.DeviceViewModel();
        public DevicesPage()
        {
            InitializeComponent();
            this.DataContext = DeviceViewModel;
        }
    }
}
