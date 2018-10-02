using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace NiceMeter.ViewModels
{
    class MainboardMeter : Meter, IMeter
    {
        public IMeter FormatText(IHardware hardware)
        {
            Name = hardware.Name;
            return this;
        }

        public IMeter FormatValues(IList<ISensor> sensors)
        {
            // Nothing is required for the mobo
            return this;
        }
    }
}
