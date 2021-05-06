using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon.Interfaces;

namespace ModelCommon
{
    public class LightBulb : IDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
