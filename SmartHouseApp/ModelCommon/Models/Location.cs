using ModelCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelCommon
{
    public class Location : ILocation
    {
        public Tuple<double, double> Coordinates { get; set; }
    }
}
