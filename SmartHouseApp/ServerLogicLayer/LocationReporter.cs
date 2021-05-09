using ModelCommon.Interfaces;
using System;

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
            var c = value.Coordinates;
            var min = _minCoordinates.Coordinates;
            var max = _maxCoordinates.Coordinates;
            if(((c.Item1 > min.Item1 && c.Item2 > min.Item2) && (c.Item1 < max.Item1 && c.Item2 < max.Item2)))
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
