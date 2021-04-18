using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Windows.Input;
using DataLayer;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using PresentationLayer.Commands;

namespace PresentationLayer.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public readonly IUserService _userService;
        
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
            _userService = new UserService(RepositoryMock.GetUsersRepository());
            _login = "";
            LoginCommand = new LoginCommand(this);
        }

        public ICommand LoginCommand { get; set; }

    }
}
