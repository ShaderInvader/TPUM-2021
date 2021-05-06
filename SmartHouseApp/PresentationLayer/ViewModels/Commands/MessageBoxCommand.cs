using System;
using System.Windows;
using System.Windows.Input;

namespace ClientPresentationLayer.ViewModels
{
    public class MessageBoxCommand : ICommand
    {
        private readonly ICommand _yesCommand;
        private readonly ICommand _noCommand;
        private readonly string _message;
        private readonly string _windowTitle;

        public MessageBoxCommand(ICommand YesCommand, ICommand NoCommand, string message, string windowTitle = "Warning")
        {
            _yesCommand = YesCommand;
            _noCommand = NoCommand;
            _message = message;
            _windowTitle = windowTitle;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return (_yesCommand?.CanExecute(null) ?? true) && (_noCommand?.CanExecute(null) ?? true);
        }

        public void Execute(object parameter)
        {
            var Result = MessageBox.Show(_message, _windowTitle, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (Result == MessageBoxResult.Yes)
            {
                _yesCommand?.Execute(null);
            }
            else
            {
                _noCommand?.Execute(null);
            }
        }
    }
}
