using ModelCommon.Interfaces;
using System;
using System.Collections.Generic;

namespace ServerLogicLayer
{
    public class LocationTracker : IObservable<ILocation>
    {
        private List<IObserver<ILocation>> _observers;
        public LocationTracker()
        {
            _observers = new List<IObserver<ILocation>>();
        }

        public IDisposable Subscribe(IObserver<ILocation> observer)
        {
            if(!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }

        public void TrackLocation(ILocation location)
        {
            foreach(var o in _observers)
            {
                if(location == null)
                {
                    o.OnError(new Exception("Location Unknown"));
                }
                else
                {
                    o.OnNext(location);
                }
            }
        }

        public void EndTransmission()
        {
            foreach(var observer in _observers)
            {
                observer.OnCompleted();
            }
            _observers.Clear();
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<ILocation>> _observers;
            private IObserver<ILocation> _observer;

            public Unsubscriber(List<IObserver<ILocation>> observers, IObserver<ILocation> observer)
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
