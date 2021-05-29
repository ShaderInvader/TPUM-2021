using System.Windows;

namespace ClientPresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private ViewModels.LoginViewModel LoginViewModel { get; set; } = new ViewModels.LoginViewModel();
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = LoginViewModel;
        }
    }
}
