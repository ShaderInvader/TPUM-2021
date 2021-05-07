using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLogicLayer.Services
{
    public class ConnectionService
    {
        public bool Connected { get; set; }

        public async Task<bool> Connect(Uri peerUri)
        {
            // TODO: implementation
            Connected = peerUri.OriginalString != "";
            return Connected;
        }
    }
}
