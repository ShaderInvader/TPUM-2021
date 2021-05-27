using System;
using ClientDataLayer.Interfaces;

namespace ClientDataLayer
{
    public class Location : ILocation
    {
        public Tuple<double, double> Coordinates { get; set; }
    }
}
