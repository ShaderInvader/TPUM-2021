using LogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.MOCKs
{
    class DevicesMock
    {
        public static List<DeviceDTO> devicesMock = new List<DeviceDTO>()
        {
            new DeviceDTO(){Id = 1, Name = "Philips Hue Bluetooth White and Color Ambiance Bulb", Type="Light Bulb", Enabled = true},
            new DeviceDTO(){Id = 2, Name = "Yeelight Smart LED Bulb", Type="Light Bulb", Enabled = true},
            new DeviceDTO(){Id = 3, Name = "Mi Smart Motion Sensor", Type="Motion Detector", Enabled = false},
            new DeviceDTO(){Id = 4, Name = "Mi Smart Motion Sensor", Type="Motion Detector", Enabled = false},
            new DeviceDTO(){Id = 5, Name = "Dahua's Smart Motion Detection", Type="Motion Detector", Enabled = true},
            new DeviceDTO(){Id = 6, Name = "Gosund Smart Socket SP1-C", Type="Wall Socket", Enabled = true},
            new DeviceDTO(){Id = 7, Name = "Gosund Smart Socket SP1-C", Type="Wall Socket", Enabled = false},
        };
    }
}
