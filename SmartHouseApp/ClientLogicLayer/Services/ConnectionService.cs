using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using ClientDataLayer;

namespace ClientLogicLayer.Services
{
    public class ConnectionService
    {
        public bool Connected => clientSocketConnection != null;
        public WebSocketConnection clientSocketConnection;

        public Action<string> connectionLogger;

        public async Task<bool> Connect(Uri peerUri, Action<string> logger)
        {
            try
            {
                connectionLogger = logger;
                connectionLogger?.Invoke($"Establishing connection to {peerUri.OriginalString}");

                clientSocketConnection = await WebSocketClient.Connect(peerUri, connectionLogger);
                
                return true;
            }
            catch (WebSocketException e)
            {
                Debug.WriteLine($"Caught web socket exception {e.Message}");
                connectionLogger?.Invoke(e.Message);
                return false;
            }

        }

        public async Task Disconnect()
        {
            await clientSocketConnection.DisconnectAsync();
            clientSocketConnection = null;
        }
    }
}
