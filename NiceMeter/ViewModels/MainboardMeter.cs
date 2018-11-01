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
            // No sensors for the mobo
            return this;
        }

        public IMeter GetDisplayMeter()
        {
            return this;
        }

        public void UpdateMeter(IList<ISensor> sensors)
        {
            // Nothing to update
        }
    }
}
