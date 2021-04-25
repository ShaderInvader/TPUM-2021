using System;
using System.Windows.Input;

namespace PresentationLayer.ViewModels.Commands
{
    class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _loginViewModel.Login != "";
        }

        public void Execute(object parameter)
        {
            // TODO: remove hardcoded password
            _loginViewModel._userService.LoginUser(_loginViewModel.Login, "admin");
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
