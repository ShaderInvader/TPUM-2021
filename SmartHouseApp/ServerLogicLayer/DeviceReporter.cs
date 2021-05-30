using ServerDataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogicLayer
{
    public class DeviceReporter : IObserver<IDevice>
    {
        private IDisposable _unsubscriber = null;
        private Action _onComplete = null;
        private Action<ExampleDeviceDTO> _onNext = null;
        private Action<Exception> _onError = null;

        public virtual void Subscribe(IObservable<IDevice> provider, Action onComplete, Action<Exception> onError, Action<ExampleDeviceDTO> onNext)
        {
            _onComplete = onComplete;
            _onError = onError;
            _onNext = onNext;
            if (provider != null)
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

        public void OnNext(IDevice value)
        {
            _onNext?.Invoke(Mapper.Map(value));
        }
    }
}
