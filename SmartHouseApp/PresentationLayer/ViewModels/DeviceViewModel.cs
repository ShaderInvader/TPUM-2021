using DataLayer;
using LogicLayer.DTOs;
using LogicLayer.Interfaces;
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
        private ObservableCollection<DeviceDTO> _devices;
        private readonly IDeviceService _deviceService;
        private DeviceDTO _selectedDevice;
        private bool _newDevice;

        public DeviceViewModel()
        {
            _deviceService = new DeviceService(RepositoryMock.GetDeviceRepository());
            _devices = new ObservableCollection<DeviceDTO>(_deviceService.GetDevices());
            _selectedDevice = _devices[0];
            _newDevice = false;
            NewDeviceCommand = new NewDeviceCommand(this);
            SaveDeviceCommand = new SaveDeviceCommand(this);
        }

        public ObservableCollection<DeviceDTO> Devices
        {
            get
            {
                _devices = new ObservableCollection<DeviceDTO>(_deviceService.GetDevices());
                return _devices;
            }
            set
            {
                _devices = value;
                OnPropertyChanged("Devices");
            }
        }

        public DeviceDTO SelectedDevice
        {
            get => _selectedDevice;
            set
            {
                _selectedDevice = value;
                OnPropertyChanged("SelectedDevice");
            }
        }

        public DeviceService DeviceService
        {
            get
            {
                return (DeviceService)_deviceService;
            }
        }

        public bool NewDevice
        {
            get => _newDevice;
            set
            {
                _newDevice = value;
                OnPropertyChanged("NewDevice");
                OnPropertyChanged("Devices");
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
            deviceViewModel.DeviceService.AddDevice(deviceViewModel.SelectedDevice);
            deviceViewModel.SelectedDevice = deviceViewModel.Devices[0];
            deviceViewModel.NewDevice = false;
        }
    }
}
