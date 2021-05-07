using System;
using System.Collections.Generic;
using System.Text;

namespace ModelCommon.Interfaces
{
    public interface IDevice : INamed
    {
        public bool Enabled { get; set; }
    }
}
