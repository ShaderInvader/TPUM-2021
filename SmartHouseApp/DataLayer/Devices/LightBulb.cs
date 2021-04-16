using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Interfaces;

namespace DataLayer.Devices
{
    class LightBulb : IDevice
    {
        int IData.Id { get; set; }
        string IDevice.Name { get; set; }
        bool IDevice.Enabled { get; set; }
    }
}
