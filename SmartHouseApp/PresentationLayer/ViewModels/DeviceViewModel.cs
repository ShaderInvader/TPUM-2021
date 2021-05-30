using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ClientLogicLayer;
using ClientLogicLayer.Interfaces;
using ClientLogicLayer.InternalDTOs;
using ClientLogicLayer.Services;
using ClientPresentationLayer.ViewModels.Commands;

namespace ClientPresentationLayer.ViewModels
{
    public class DeviceViewModel : BaseViewModel
    {
        private ObservableCollection<DeviceDTO> _devices;
        private readonly IDeviceService _deviceService;
        private DeviceDTO _selectedDevice;
        private bool _editDevice;

        public DeviceViewModel()
        {
            _deviceService = ServiceFactory.CreateDeviceService;
            _deviceService.DevicesChange += UpdateDevices;
            _deviceService.OnDeviceChanged += UpdateDevice;
            _devices = new ObservableCollection<DeviceDTO>();
            _editDevice = false;

            NavigationViewModel.ConnectionEstablishedEvent += RequestDevices;
            NavigationViewModel.ConnectionLostEvent += CleanDevices;

            NewDeviceCommand = new NewDeviceCommand(this);
            ToggleDeviceCommand = new ToggleDeviceCommand(this);
            SaveDeviceCommand = new AddDeviceCommand(this);
            EditDeviceCommand = new EditDeviceCommand(this);
            DeleteDeviceCommand = new MessageBoxCommand(new DeleteDeviceCommand(this), null, "Do you really want to delete this device?");
        }

        private void CleanDevices()
        {
            Devices.Clear();
        }

        private async void RequestDevices()
        {
            await _deviceService.RefreshDevices();
        }

        ~DeviceViewModel()
        {
            _deviceService.DevicesChange -= UpdateDevices;
            _deviceService.OnDeviceChanged -= UpdateDevice;
        }

        #region Properties

        public ObservableCollection<DeviceDTO> Devices
        {
            get => _devices;
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
                if(_selectedDevice != null)
                {
                    _deviceService.DisposeDevice(_selectedDevice);
                }
                _selectedDevice = value;
                if (_selectedDevice != null)
                {
                    _deviceService.SubscribeDevice(_selectedDevice);
                }
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

        public bool EditDevice
        {
            get => _editDevice;
            set
            {
                _editDevice = value;
                OnPropertyChanged("EditDevice");
                OnPropertyChanged("Devices");
                OnPropertyChanged("EditDeviceInv");
            }
        }

        public bool EditDeviceInv
        {
            get => !EditDevice;
        }

        #endregion


        #region ICommands
        public ICommand NewDeviceCommand { get; set; }
        public ICommand ToggleDeviceCommand { get; set; }
        public ICommand SaveDeviceCommand { get; set; }
        public ICommand EditDeviceCommand { get; set; }
        public ICommand DeleteDeviceCommand { get; set; }
        #endregion

        public void UpdateDevices()
        {
            _devices = new ObservableCollection<DeviceDTO>(_deviceService.GetDevices());
            OnPropertyChanged("Devices");
        }

        public void UpdateDevice(DeviceDTO device)
        {
            for(int i = 0; i < _devices.Count; ++i)
            {
                if(_devices[i].Id == device.Id)
                {
                    _devices[i].Enabled = device.Enabled;
                    break;
                }
            }
            OnPropertyChanged("SelectedDevice");
            OnPropertyChanged("Devices");
        }
    }
}
