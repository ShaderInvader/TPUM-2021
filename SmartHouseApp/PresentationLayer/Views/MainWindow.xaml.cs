using System.Windows;

namespace ClientPresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModels.NavigationViewModel navigationViewModel { get; set; } = new ViewModels.NavigationViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = navigationViewModel;
        }
    }
}
