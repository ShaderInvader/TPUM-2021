using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ServerLogicLayer;

namespace ServerPresentationLayer
{
    public static class Serializer
    {
        private static IDeviceService deviceService = new DeviceService();

        public static string AllDataToJson()
        {
            var devices = deviceService.GetDevices().Result;

            string returnString = "Devices";
            returnString += JsonSerializer.Serialize(devices);

            return returnString;
        }
    }
}
