using ClientPresentationLayer.ViewModels.Util.Interfaces;
using System;
using System.Threading.Tasks;

namespace ClientPresentationLayer.ViewModels.Util
{
    public static class TaskUtil
    {
        public static async void HandleErrors(this Task task, IErrorHandler handler = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}
