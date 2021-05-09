using System;
using System.Windows.Input;

namespace ClientPresentationLayer.ViewModels.Commands
{
    public class ToggleDeviceCommand : ICommand
    {
        private readonly DeviceViewModel deviceViewModel;
        public ToggleDeviceCommand(DeviceViewModel deviceViewModel)
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
            return deviceViewModel.Devices.Count > 0 && deviceViewModel.SelectedDevice != null;
        }

        public void Execute(object parameter)
        {
            deviceViewModel.DeviceService.ToggleDevice(deviceViewModel.SelectedDevice.Id);
            deviceViewModel.EditDevice = false;
        }
    }
}
