using System.Threading.Tasks;

namespace ClientLogicLayer.Interfaces
{
    public interface ILocationService
    {
        public Task StartTracking();
        public void StopTracking();
    }
}
