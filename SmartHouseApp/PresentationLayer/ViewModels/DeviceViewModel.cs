using LogicLayer.DTOs;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    class DeviceViewModel : BaseViewModel
    {
        private ObservableCollection<DeviceDTO> devices;
        private DeviceDTO selectedDevice;
        //private readonly DeviceService deviceService;
        private bool newDevice;

        public DeviceViewModel()
        {
            devices = new ObservableCollection<DeviceDTO>(MOCKs.DevicesMock.devicesMock);
            selectedDevice = devices[0];
            newDevice = false;
            NewDeviceCommand = new NewDeviceCommand(this);
            SaveDeviceCommand = new SaveDeviceCommand(this);
        }

        public ObservableCollection<DeviceDTO> Devices
        {
            get => devices;
            set
            {
                devices = value;
                OnPropertyChanged("Devices");
            }
        }

        public DeviceDTO SelectedDevice
        {
            get => selectedDevice;
            set
            {
                selectedDevice = value;
                OnPropertyChanged("SelectedDevice");
            }
        }

        //public DeviceService DeviceService
        //{
        //    get => deviceService;
        //}

        public bool NewDevice
        {
            get => newDevice;
            set
            {
                newDevice = value;
                OnPropertyChanged("NewDevice");
                OnPropertyChanged("OldDevice");
            }
        }

        public bool OldDevice
        {
            get => !NewDevice;
        }

        #region ICommands
        public ICommand NewDeviceCommand { get; set; }
        public ICommand SaveDeviceCommand { get; set; }
        #endregion
    }

    class NewDeviceCommand : ICommand
    {
        private readonly DeviceViewModel deviceViewModel;
        public NewDeviceCommand(DeviceViewModel deviceViewModel)
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
            deviceViewModel.NewDevice = true;
            deviceViewModel.SelectedDevice = new DeviceDTO();
        }
    }

    class SaveDeviceCommand : ICommand
    {
        private readonly DeviceViewModel deviceViewModel;
        public SaveDeviceCommand(DeviceViewModel deviceViewModel)
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
            deviceViewModel.NewDevice = false;
            deviceViewModel.SelectedDevice = deviceViewModel.Devices[deviceViewModel.Devices.Count - 1];
        }
    }
}
