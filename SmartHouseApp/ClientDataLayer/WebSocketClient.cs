using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDataLayer
{

    public static class WebSocketClient
    {
        public static WebSocketConnection CurrentConnection { get; private set; }

        public static async Task<WebSocketConnection> Connect(Uri peer, Action<string> log)
        {
            ClientWebSocket clientWebSocket = new ClientWebSocket();

            await clientWebSocket.ConnectAsync(peer, CancellationToken.None);

            switch (clientWebSocket.State)
            {
                case WebSocketState.Open:
                    // Connection log invoke
                    log?.Invoke($"Opened connection to remote server: {peer}");

                    // ===== Creating socket connection object =====
                    WebSocketConnection socketConnection = new ClientWebSocketConnection(clientWebSocket, peer, log);
                    // ===== Attaching data parser to on message event =====
                    socketConnection.OnMessage = (x) => Debug.WriteLine(x);
                    
                    // Setting the current connection for singleton connection implementation
                    CurrentConnection = socketConnection;

                    return socketConnection;
                    
                default:
                    string errMsg = $"Cannot connect to remote server {peer} with status {clientWebSocket.State}";
                    log?.Invoke(errMsg);
                    throw new WebSocketException(errMsg);
            }
        }

        public static async Task Disconnect()
        {
            await CurrentConnection.DisconnectAsync();
            CurrentConnection = null;
        }

        private class ClientWebSocketConnection : WebSocketConnection
        {
            private readonly ClientWebSocket _clientWebSocket = null;
            private Uri _peer = null;
            private readonly Action<string> _log;

            public ClientWebSocketConnection(ClientWebSocket clientWebSocket, Uri peer, Action<string> log)
            {
                _log = log;
                _peer = peer;
                _clientWebSocket = clientWebSocket;
                Task.Factory.StartNew(ClientMessageLoop);
            }

            public override bool IsConnected => _clientWebSocket.State == WebSocketState.Open;

            public override Task DisconnectAsync()
            {
                return _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Shutdown procedure started", CancellationToken.None);
            }

            protected override Task SendTask(string message)
            {
                return _clientWebSocket.SendAsync(message.GetArraySegment(), WebSocketMessageType.Text, true, CancellationToken.None); ;
            }

            private void ClientMessageLoop()
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
                        WebSocketReceiveResult result = _clientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            OnClose?.Invoke();
                            _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "I am closing", CancellationToken.None).Wait();
                            return;
                        }
                        int count = result.Count;
                        while (!result.EndOfMessage)
                        {
                            if (count >= buffer.Length)
                            {
                                OnClose?.Invoke();
                                _clientWebSocket.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None).Wait();
                                return;
                            }
                            segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                            result = _clientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                            count += result.Count;
                        }
                        string _message = Encoding.UTF8.GetString(buffer, 0, count);
                        OnMessage?.Invoke(_message);
                    }
                }
                catch (Exception _ex)
                {
                    _log($"Connection has been broken because of an exception {_ex}");
                    _clientWebSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, "Connection has been broken because of an exception", CancellationToken.None).Wait();
                }
            }
        }

        internal static ArraySegment<byte> GetArraySegment(this string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            return new ArraySegment<byte>(buffer);
        }
    }
}
