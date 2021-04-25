using System;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    public class DeleteDeviceCommand : ICommand
    {
        private readonly DeviceViewModel deviceViewModel;
        public DeleteDeviceCommand(DeviceViewModel deviceViewModel)
        {
            this.deviceViewModel = deviceViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return deviceViewModel.Devices.Count > 0;
        }

        public void Execute(object parameter)
        {
            deviceViewModel.DeviceService.RemoveDevice(deviceViewModel.SelectedDevice);
        }
    }
}
