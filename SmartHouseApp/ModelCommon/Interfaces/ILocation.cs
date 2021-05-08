using System;
using System.Collections.Generic;
using System.Text;

namespace ModelCommon.Interfaces
{
    public interface ILocation
    {
        public Tuple<double, double> Coordinates { get; set; }
    }
}
