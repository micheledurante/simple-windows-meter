﻿using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.Interfaces
{
    public interface IMeter
    {
        IMeter FormatText(IHardware hardware);

        IMeter FormatValues(IList<ISensor> sensors);
    }
}
