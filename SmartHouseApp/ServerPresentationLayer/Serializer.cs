using System.Text.Json;
using ServerLogicLayer;

namespace ServerPresentationLayer
{
    public static class Serializer
    {

        public static string AllDataToJson(IDeviceService deviceService)
        {
            var devices = deviceService.GetDevices().Result;

            string returnString = "Devices";
            returnString += JsonSerializer.Serialize(devices);

            return returnString;
        }

        public static int IntFromJson(string json)
        {
            return JsonSerializer.Deserialize<int>(json);
        }

        public static ExampleDeviceDTO DeviceFormJson(string json)
        {
            return JsonSerializer.Deserialize<ExampleDeviceDTO>(json);
        }
    }
}
