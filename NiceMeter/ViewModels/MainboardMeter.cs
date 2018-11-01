using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace NiceMeter.ViewModels
{
    class MainboardMeter : Meter, IMeter
    {
        public MainboardMeter(string name)
        {
            Name = name;
        }

        public IMeter FormatSensors(IList<ISensor> sensors)
        {
            // Nothing is required for the mobo
            return this;
        }

        public IMeter GetDisplayValue()
        {
            return this;
        }
    }
}
