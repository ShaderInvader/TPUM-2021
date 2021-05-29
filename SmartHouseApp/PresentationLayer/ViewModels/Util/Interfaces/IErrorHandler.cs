using System;

namespace ClientPresentationLayer.ViewModels
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
