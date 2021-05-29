using System;
using System.Threading.Tasks;

namespace ClientDataLayer.Interfaces
{
    public interface ILocationController
    {
        public ILocation CurrentLocation { get; set; }
        public Task TrackPosition();
        public void StopTracking();
    }
}
