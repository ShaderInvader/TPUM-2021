using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon.Interfaces;

namespace ModelCommon
{
    public class ExampleDevice : IDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool LastState { get; set; }
    }
}
