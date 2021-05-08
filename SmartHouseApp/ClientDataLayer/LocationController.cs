using System;
using System.Collections.Generic;
using System.Text;
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

        public Tuple<double, double> CurrentLocation { get; set; } = new Tuple<double, double>(0.0, 0.0);
        private bool isTracking;
        public async Task TrackPosition()
        {
            isTracking = true;
            while (isTracking)
            {
                await WebSocketClient.CurrentConnection.SendAsync($"Location:{CurrentLocation}");
                CurrentLocation = new Tuple<double, double>(CurrentLocation.Item1 + 5.0, CurrentLocation.Item2);
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void StopTracking()
        {
            isTracking = false;
        }
    }
}
