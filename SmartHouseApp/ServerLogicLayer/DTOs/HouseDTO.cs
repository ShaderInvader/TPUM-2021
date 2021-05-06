using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon.Interfaces;

namespace ServerLogicLayer
{
    public class HouseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IDevice> Devices { get; set; }
        public Tuple<double, double> Location { get; set; }
    }
}
