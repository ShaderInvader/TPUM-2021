using ModelCommon.Interfaces;
using System;

namespace ModelCommon
{
    public class Location : ILocation
    {
        public Tuple<double, double> Coordinates { get; set; }
    }
}
