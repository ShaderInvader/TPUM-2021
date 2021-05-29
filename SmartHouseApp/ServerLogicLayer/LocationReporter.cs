using System;
using ServerDataLayer.Interfaces;

namespace ServerLogicLayer
{
    public class LocationReporter : IObserver<ILocation>
    {
        private IDisposable _unsubscriber = null;

        private readonly ILocation _minCoordinates;
        private readonly ILocation _maxCoordinates;

        private Action _onComplete = null;
        private Action<Exception> _onError = null;
        private Action<LocationDTO> _onNext = null;
        private Action _onHouseLeft = null;
        private Action _onHouseEnter = null;
        private bool _inHouse = true;

        public LocationReporter(ILocation minCoordinates, ILocation maxCoordinates)
        {
            _minCoordinates = minCoordinates;
            _maxCoordinates = maxCoordinates;
        }

        public virtual void Subscribe(IObservable<ILocation> provider, Action onComplete, Action<Exception> onError, Action<LocationDTO> onNext, Action onHouseLeft, Action onHouseEnter)
        {
            _onComplete = onComplete;
            _onError = onError;
            _onNext = onNext;
            _onHouseLeft = onHouseLeft;
            _onHouseEnter = onHouseEnter;
            if(provider != null)
            {
                _unsubscriber = provider.Subscribe(this);
            }
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber?.Dispose();
        }

        public void OnCompleted()
        {
            _onComplete?.Invoke();
            this.Unsubscribe();
        }

        public void OnError(Exception error)
        {
            _onError?.Invoke(error);
        }

        public void OnNext(ILocation value)
        {
            LocationDTO loc = Mapper.Map(value);
            _onNext?.Invoke(loc);
            var c = value;
            var min = _minCoordinates;
            var max = _maxCoordinates;
            if(c.Longitude > min.Longitude && c.Latitude > min.Latitude 
                && c.Longitude < max.Longitude && c.Latitude < max.Latitude)
            {
                if(!_inHouse)
                {
                    _onHouseEnter?.Invoke();
                    _inHouse = true;
                }
            }
            else
            {
                if (_inHouse)
                {
                    _onHouseLeft?.Invoke();
                    _inHouse = false;
                }
            }
        }
    }
}
