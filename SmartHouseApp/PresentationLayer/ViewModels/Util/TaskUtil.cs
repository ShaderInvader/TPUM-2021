using System;
using System.Threading.Tasks;

namespace ClientPresentationLayer.ViewModels
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
