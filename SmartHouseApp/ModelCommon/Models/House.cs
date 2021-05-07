using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon.Interfaces;

namespace ModelCommon
{
    public class House : INamed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IDevice> Devices { get; set; }
        public Tuple<double, double> Location { get; set; }
        public List<User> Users { get; set; }
    }
}
