using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using ModelCommon;

namespace LogicLayer
{
    class DisableLightsOnLocationChange : ILocationChanged
    {
        private readonly int refreshInterval = 1000;
        private readonly double triggerDistance = 50.0f;

        public event Action LocationLeft;
        public event Action LocationEntered;

        private IDeviceService _deviceService;
        private User _trackedUser;

        private Tuple<double, double> savedLocation;
        private bool wasInRange = false;
        private bool isTracking = false;

        public DisableLightsOnLocationChange(IDeviceService deviceService, User trackedUser)
        {
            _deviceService = deviceService;
            _trackedUser = trackedUser;
        }

        public void StartTracking()
        {
            Task.Run(TrackLocation);
            isTracking = true;
        }

        public void StopTracking()
        {
            isTracking = false;
        }

        private void TrackLocation()
        {
            while (isTracking)
            {
                if (Math.Abs(_trackedUser.Location.Item1 - savedLocation.Item1) > triggerDistance ||
                    Math.Abs(_trackedUser.Location.Item2 - savedLocation.Item2) > triggerDistance)
                {
                    if (wasInRange)
                    {
                        OnLeft();
                    }

                    wasInRange = false;
                }
                else
                {
                    if (!wasInRange)
                    {
                        OnEntered();
                    }

                    wasInRange = true;
                }
                Thread.Sleep(refreshInterval);
            }
        }

        private void OnLeft()
        {
            LocationLeft?.Invoke();
        }

        private void OnEntered()
        {
            LocationEntered?.Invoke();
        }
    }
}
