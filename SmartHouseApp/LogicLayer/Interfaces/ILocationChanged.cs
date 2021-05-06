﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public interface ILocationChanged
    {
        public event Action LocationLeft;
        public event Action LocationEntered;

        public void StartTracking();
        public void StopTracking();
    }
}
