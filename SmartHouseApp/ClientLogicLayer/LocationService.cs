using System.Threading.Tasks;
using ClientDataLayer;
using ClientDataLayer.Interfaces;
using ClientLogicLayer.Interfaces;

namespace ClientLogicLayer
{
    class LocationService : ILocationService
    {
        private readonly ILocationController _locationController;

        public LocationService()
        {
            _locationController = LocationController.Instance;
        }

        public async Task StartTracking()
        {
            await _locationController.TrackPosition();
        }

        public void StopTracking()
        {
            _locationController.StopTracking();
        }
    }
}
