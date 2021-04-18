using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Exceptions
{
    [Flags]
    public enum DeviceField
    {
        Id,
        Name,
        Enabled,
        Type
    }

    public class InvalidDeviceDataException : Exception
    {
        public InvalidDeviceDataException(DeviceField invalidFields) 
            : base("Invalid device fields detected")
        { }
    }
}
