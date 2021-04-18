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
using System.Windows.Shapes;

namespace PresentationLayer.Views
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
