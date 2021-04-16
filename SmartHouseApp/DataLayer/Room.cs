﻿using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Devices;

namespace DataLayer
{
    class Room : IData
    {
        int IData.Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SmartDevice> Devices { get; set; }
    }
}
