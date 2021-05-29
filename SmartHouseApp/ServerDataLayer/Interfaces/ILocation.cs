using System;

namespace ServerDataLayer.Interfaces
{
    public interface ILocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
