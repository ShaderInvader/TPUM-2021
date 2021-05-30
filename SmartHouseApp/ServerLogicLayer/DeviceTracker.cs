using ServerDataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogicLayer
{
    public class DeviceTracker : IObservable<IDevice>
    {
        private readonly List<IObserver<IDevice>> _observers;

        public DeviceTracker()
        {
            _observers = new List<IObserver<IDevice>>();
        }

        public IDisposable Subscribe(IObserver<IDevice> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }

        public void TrackDevice(IDevice device)
        {
            foreach(var o in _observers)
            {
                if(device == null)
                {
                    o.OnError(new Exception("Device is null"));
                }
                else
                {
                    o.OnNext(device);
                }
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }
            _observers.Clear();
        }

        private class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<IDevice>> _observers;
            private readonly IObserver<IDevice> _observer;

            public Unsubscriber(List<IObserver<IDevice>> observers, IObserver<IDevice> observer)
            {
                _observer = observer;
                _observers = observers;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
