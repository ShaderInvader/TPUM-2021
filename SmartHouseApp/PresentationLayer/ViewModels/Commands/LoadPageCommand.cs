using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ClientPresentationLayer.ViewModels.Commands
{
    class LoadPageCommand : ICommand
    {
        private readonly NavigationViewModel navigationViewModel;
        private readonly string uri;
        private readonly bool shouldExecute;

        public LoadPageCommand(NavigationViewModel navigationViewModel, string uri, bool shouldExecute = true)
        {
            this.navigationViewModel = navigationViewModel;
            this.uri = uri;
            this.shouldExecute = shouldExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            if (shouldExecute)
            {
                return navigationViewModel.CheckConnection();
            }
            return false;
        }

        public void Execute(object parameter)
        {
            navigationViewModel.CurrentPage = uri;
        }
    }
}
