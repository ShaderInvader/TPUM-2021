using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PresentationLayer.Commands
{
    public class AddDeviceCommand : ICommand
    {
        private readonly DeviceViewModel deviceViewModel;
        public AddDeviceCommand(DeviceViewModel deviceViewModel)
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
            deviceViewModel.DeviceService.AddDevice(deviceViewModel.SelectedDevice);
            deviceViewModel.EditDevice = false;
        }
    }
}
