using System;

namespace ClientDataLayer.Interfaces
{
    public interface ILocation
    {
        public Tuple<double, double> Coordinates { get; set; }
    }
}
