using System;

namespace PresentationLayer.ViewModels.Util.Interfaces
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
