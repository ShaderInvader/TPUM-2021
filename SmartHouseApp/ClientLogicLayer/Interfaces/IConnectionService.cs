using System;
using System.Threading.Tasks;

namespace ClientLogicLayer.Interfaces
{
    public interface IConnectionService
    {
        public Action<string> ConnectionLogger { get; set; }

        public bool Connected { get; }
        public Task<bool> Connect(Uri peerUri);
        public Task Disconnect();
    }
}
