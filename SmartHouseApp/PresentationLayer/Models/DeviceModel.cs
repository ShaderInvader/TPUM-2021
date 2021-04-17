using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    class DeviceModel
    {
        private int id;
        private string type;
        private bool enabled;

        public int ID
        { 
            get => id;
            set => id = value;
        }
        public string Type
        {
            get => type;
            set => type = value;
        }
        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }
    }
}
