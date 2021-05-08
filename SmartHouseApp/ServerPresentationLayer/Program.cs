using System;
using System.Threading.Tasks;

namespace ServerPresentationLayer
{
    class Program
    {
        private static WebSocketConnection CurrentConnection;
        static async Task Main(string[] args)
        {
            await WebSocketServer.Server(8081, ConnectionHandler);
        }

        static void ConnectionHandler(WebSocketConnection webSocketConnection)
        {
            CurrentConnection = webSocketConnection;
            webSocketConnection.onMessage = ParseMessage;
            webSocketConnection.onClose = () => { Console.WriteLine("Connection closed"); };
            webSocketConnection.onError = () => { Console.WriteLine("Connection error encountered"); };
        }

        static void ParseMessage(string message)
        {
            Console.WriteLine(message);
            if(message.Contains("UpdateDataRequest"))
            {
                Task.Run(() => CurrentConnection.SendAsync(Serializer.AllDataToJson()));
            }
        }
    }
}
