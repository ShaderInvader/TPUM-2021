using System;
using System.Threading.Tasks;
using ClientDataLayer.Interfaces;

namespace ClientDataLayer
{
    public class LocationController : ILocationController
    {
        private static LocationController _instance;
        public static LocationController Instance
        {
            get { return _instance ??= new LocationController(); }
            private set => _instance = value;
        }

        public ILocation CurrentLocation { get; set; } = new Location() {Latitude = 0.0, Longitude = 0.0 };
        private bool isTracking;
        public async Task TrackPosition()
        {
            isTracking = true;
            double valToAdd = 1;
            while (isTracking)
            {
                await WebSocketClient.CurrentConnection.SendAsync(MessageParser.CreateMessage("OnNext", CurrentLocation, CurrentLocation.GetType().Name));
                if(CurrentLocation.Latitude > 20)
                {
                    valToAdd = -1;
                }
                else if(CurrentLocation.Latitude < -20)
                {
                    valToAdd = 1;
                }
                CurrentLocation.Latitude += valToAdd;
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void StopTracking()
        {
            isTracking = false;
        }
    }
}
