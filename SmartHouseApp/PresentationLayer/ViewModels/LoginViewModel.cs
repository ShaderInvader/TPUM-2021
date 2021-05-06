using System.Windows.Input;
using LogicLayer;

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
            _userService = new UserService(RepositoryPlaceholder.GetUsersRepository());
            _login = "";
            LoginCommand = new LoginCommand(this);
        }

        public ICommand LoginCommand { get; set; }

    }
}
