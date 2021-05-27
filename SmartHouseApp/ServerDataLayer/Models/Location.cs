using System;
using ServerDataLayer.Interfaces;

namespace ServerDataLayer
{
    public class Location : ILocation
    {
        public Tuple<double, double> Coordinates { get; set; }
    }
}
