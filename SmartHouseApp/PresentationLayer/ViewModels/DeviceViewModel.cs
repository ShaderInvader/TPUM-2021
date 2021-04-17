using LogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;

namespace PresentationLayer.ViewModels
{
    class DeviceViewModel : BaseViewModel
    {
        private ObservableCollection<DeviceDTO> devices;

        private DeviceDTO selectedDevice;

        public DeviceViewModel()
        {
            devices = new ObservableCollection<DeviceDTO>(MOCKs.DevicesMock.devicesMock);
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
    }

}
