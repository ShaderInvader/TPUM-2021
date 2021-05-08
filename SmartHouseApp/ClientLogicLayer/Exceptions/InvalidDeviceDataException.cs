using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLogicLayer
{
    [Flags]
    public enum DeviceField
    {
        None,
        Id,
        Name,
        Enabled
    }

    public class InvalidDeviceDataException : Exception
    {
        public InvalidDeviceDataException(DeviceField invalidFields) 
            : base("Invalid device fields detected")
        { }
    }
}
