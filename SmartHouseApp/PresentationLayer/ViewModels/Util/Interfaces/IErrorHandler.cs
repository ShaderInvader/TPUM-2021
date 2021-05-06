using System;

namespace ClientPresentationLayer.ViewModels.Util.Interfaces
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
