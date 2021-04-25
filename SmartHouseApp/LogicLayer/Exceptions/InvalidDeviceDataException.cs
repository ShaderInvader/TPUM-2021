using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    [Flags]
    public enum DeviceField
    {
        None,
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
