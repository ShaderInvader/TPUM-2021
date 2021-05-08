using System.Windows.Input;
using ClientLogicLayer;
using ClientPresentationLayer.ViewModels.Commands;
using LogicLayer;
using LogicLayer.Interfaces;

namespace ClientPresentationLayer.ViewModels
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
            _userService = ServiceFactory.CreateUserService;
            _login = "";
            LoginCommand = new LoginCommand(this);
        }

        public ICommand LoginCommand { get; set; }

    }
}
