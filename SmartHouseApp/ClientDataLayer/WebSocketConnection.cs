using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataLayer
{
    public abstract class WebSocketConnection
    {
        public virtual Action<string> OnMessage { set; protected get; } = x => { };
        public virtual Action OnClose { set; protected get; } = () => { };
        public virtual Action OnError { set; protected get; } = () => { };

        public virtual bool IsConnected { get; }

        public async Task SendAsync(string message)
        {
            await SendTask(message);
        }

        public abstract Task DisconnectAsync();

        protected abstract Task SendTask(string message);
    }
}
