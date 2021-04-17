using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;

namespace PresentationLayer.ViewModels
{
    class DeviceViewModel : BaseViewModel
    {
        private ObservableCollection<DeviceModel> devices;

        public DeviceViewModel()
        {
            devices = new ObservableCollection<DeviceModel>() 
            { 
                new DeviceModel() {ID = 1, Type = "Lodówka", Enabled = false},
                new DeviceModel() {ID = 2, Type = "Telewizor", Enabled = true},
                new DeviceModel() {ID = 3, Type = "Żarówka", Enabled = false},
                new DeviceModel() {ID = 4, Type = "Żarówka", Enabled = true},
                new DeviceModel() {ID = 5, Type = "Pralka", Enabled = true}
            };
        }

        public ObservableCollection<DeviceModel> Devices
        {
            get => devices;
            set
            {
                devices = value;
                OnPropertyChanged("Devices");
            }
        }
    }
}
