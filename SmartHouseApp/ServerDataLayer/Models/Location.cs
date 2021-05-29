using System;
using ServerDataLayer.Interfaces;

namespace ServerDataLayer
{
    public class Location : ILocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
