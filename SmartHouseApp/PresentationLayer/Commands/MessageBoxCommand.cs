using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer.Commands
{
    public class MessageBoxCommand : ICommand
    {
        private readonly ICommand _yesCommand;
        private readonly ICommand _noCommand;

        public MessageBoxCommand(ICommand YesCommand, ICommand NoCommand)
        {
            _yesCommand = YesCommand;
            _noCommand = NoCommand;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return (_yesCommand?.CanExecute(null) ?? true) && (_noCommand?.CanExecute(null) ?? true);
        }

        public void Execute(object parameter)
        {
            var Result = MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if( Result == MessageBoxResult.Yes)
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
