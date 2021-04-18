using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Util.Interfaces
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
