using System;
using System.Windows.Input;
using ClientLogicLayer.InternalDTOs;

namespace ClientPresentationLayer.ViewModels.Commands
{
    public class NewDeviceCommand : ICommand
    {
        private readonly DeviceViewModel deviceViewModel;
        public NewDeviceCommand(DeviceViewModel deviceViewModel)
        {
            this.deviceViewModel = deviceViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return deviceViewModel.Devices.Count > 0;
        }

        public void Execute(object parameter)
        {
            deviceViewModel.EditDevice = true;
            deviceViewModel.SelectedDevice = new DeviceDTO();
        }
    }
}
