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
            HardwareType = HardwareType.Mainboard;
        }

        public IMeter FormatText(IList<ISensor> sensors)
        {
            // Nothing is required for the mobo
            return this;
        }

        public IMeter UpdateText(IList<ISensor> sensors)
        {
            // Nothing is required for the mobo
            return this;
        }
    }
}
