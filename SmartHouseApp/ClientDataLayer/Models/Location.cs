using System;
using ClientDataLayer.Interfaces;

namespace ClientDataLayer
{
    public class Location : ILocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
