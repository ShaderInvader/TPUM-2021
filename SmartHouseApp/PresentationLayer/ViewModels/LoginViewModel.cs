using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Windows.Input;
using LogicLayer.Interfaces;

namespace PresentationLayer.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public LoginViewModel()
        {

        }

        public ICommand LoginCommand { get; set; }

    }
}
