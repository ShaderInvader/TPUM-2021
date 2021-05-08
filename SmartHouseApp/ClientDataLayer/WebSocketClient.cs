﻿using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDataLayer
{

    public static class WebSocketClient
    {
        public static async Task<WebSocketConnection> Connect(Uri peer, Action<string> log)
        {
            ClientWebSocket clientWebSocket = new ClientWebSocket();

            await clientWebSocket.ConnectAsync(peer, CancellationToken.None);

            switch (clientWebSocket.State)
            {
                case WebSocketState.Open:
                    log?.Invoke($"Opened connection to remote server: {peer}");
                    WebSocketConnection socketConnection = new ClientWebSocketConnection(clientWebSocket, peer, log);
                    return socketConnection;
                    
                default:
                    string errMsg = $"Cannot connect to remote server {peer} with status {clientWebSocket.State}";
                    log?.Invoke(errMsg);
                    throw new WebSocketException(errMsg);
            }
        }

        public class ClientWebSocketConnection : WebSocketConnection
        {
            private ClientWebSocket _clientWebSocket = null;
            private Uri _peer = null;
            private readonly Action<string> _log;

            public ClientWebSocketConnection(ClientWebSocket clientWebSocket, Uri peer, Action<string> log)
            {
                this._log = log;
                _peer = peer;
                _clientWebSocket = clientWebSocket;
                Task.Factory.StartNew(() => ClientMessageLoop());
            }

            public override Task DisconnectAsync()
            {
                throw new NotImplementedException();
            }

            protected override Task SendTask(string message)
            {
                throw new NotImplementedException();
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
                            onClose?.Invoke();
                            _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "I am closing", CancellationToken.None).Wait();
                            return;
                        }
                        int count = result.Count;
                        while (!result.EndOfMessage)
                        {
                            if (count >= buffer.Length)
                            {
                                onClose?.Invoke();
                                _clientWebSocket.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None).Wait();
                                return;
                            }
                            segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                            result = _clientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                            count += result.Count;
                        }
                        string _message = Encoding.UTF8.GetString(buffer, 0, count);
                        onMessage?.Invoke(_message);
                    }
                }
                catch (Exception _ex)
                {
                    _log($"Connection has been broken because of an exception {_ex}");
                    _clientWebSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, "Connection has been broken because of an exception", CancellationToken.None).Wait();
                }
            }
        }
    }
}
