using System;

namespace ServerDataLayer.Interfaces
{
    public interface ILocation
    {
        public Tuple<double, double> Coordinates { get; set; }
    }
}
