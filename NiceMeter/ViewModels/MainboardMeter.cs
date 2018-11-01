using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace NiceMeter.ViewModels
{
    class MainboardMeter : AbstractMeter, IMeter
    {
        public MainboardMeter(string name)
        {
            Name = name;
            HardwareType = HardwareType.Mainboard;
        }

        public IMeter FilterSensors(IList<ISensor> sensors)
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
