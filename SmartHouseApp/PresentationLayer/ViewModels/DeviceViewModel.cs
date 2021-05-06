using LogicLayer.DTOs;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using LogicLayer;
using ClientPresentationLayer.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
            _deviceService = new DeviceService(RepositoryPlaceholder.GetDeviceRepository());
            _deviceService.DeviceChange += UpdateDevices;
            _devices = new ObservableCollection<DeviceDTO>(_deviceService.GetDevices());
            _selectedDevice = _devices[0];
            _editDevice = false;
            NewDeviceCommand = new NewDeviceCommand(this);
            SaveDeviceCommand = new AddDeviceCommand(this);
            EditDeviceCommand = new EditDeviceCommand(this);
            DeleteDeviceCommand = new MessageBoxCommand(new DeleteDeviceCommand(this), null, "Do you really want to delete this device?");
        }

        ~DeviceViewModel()
        {
            _deviceService.DeviceChange -= UpdateDevices;
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
        public ICommand SaveDeviceCommand { get; set; }
        public ICommand EditDeviceCommand { get; set; }
        public ICommand DeleteDeviceCommand { get; set; }
        #endregion

        public void UpdateDevices()
        {
            _devices = new ObservableCollection<DeviceDTO>(_deviceService.GetDevices());
            OnPropertyChanged("Devices");
        }
    }
}
