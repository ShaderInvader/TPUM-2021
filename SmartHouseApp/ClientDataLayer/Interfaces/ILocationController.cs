using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataLayer.Interfaces
{
    public interface ILocationController
    {
        public Tuple<double, double> CurrentLocation { get; set; }

        public Task TrackPosition();
        public void StopTracking();
    }
}
