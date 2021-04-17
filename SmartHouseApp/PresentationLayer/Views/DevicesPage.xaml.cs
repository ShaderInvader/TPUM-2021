using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.Views
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
