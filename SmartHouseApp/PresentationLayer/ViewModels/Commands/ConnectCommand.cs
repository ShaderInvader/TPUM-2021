using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ClientPresentationLayer.ViewModels.Commands
{
    class ConnectCommand : ICommand
    {
        private readonly NavigationViewModel _navigationViewModel;

        public ConnectCommand(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _navigationViewModel.ConnectionUri != "";
        }

        public async void Execute(object parameter)
        {
            Debug.WriteLine($"Trying to connect to {_navigationViewModel.ConnectionUri}");

            try
            {
                bool connection = await _navigationViewModel.EstablishConnection(new Uri(_navigationViewModel.ConnectionUri));
                
                Debug.WriteLine($"Connection result: {(connection ? "Connected" : "Failed")}");
            }
            catch (UriFormatException e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
