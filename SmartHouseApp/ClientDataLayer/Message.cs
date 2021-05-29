using System.Text.Json;

namespace ClientDataLayer
{
    public class Message
    {
        public string Command { get; set; }
        public object Data { get; set; }
        public string DataType { get; set; }
    }
    public static class MessageParser
    {
        public static string CreateMessage(string command, object data, string dataType)
        {
            Message msg = new Message() { Command = command, Data = data, DataType = dataType };
            return JsonSerializer.Serialize(msg);
        }

        public static string CreateMessage(Message message)
        {
            return JsonSerializer.Serialize(message);
        }

        public static Message DeserializeMessage(string message)
        {
            return JsonSerializer.Deserialize<Message>(message);
        }
    }
}
