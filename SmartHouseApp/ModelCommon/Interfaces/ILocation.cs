using System;

namespace ModelCommon.Interfaces
{
    public interface ILocation
    {
        public Tuple<double, double> Coordinates { get; set; }
    }
}
