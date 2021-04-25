using System;

namespace PresentationLayer.ViewModels
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
