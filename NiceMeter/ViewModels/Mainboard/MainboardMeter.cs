using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace NiceMeter.ViewModels.Mainboard
{
    /// <summary>
    /// 
    /// </summary>
    class MainboardMeter : AbstractMeter, IMeter
    {
        public MainboardMeter(string name)
        {
            Name = name;
            HardwareType = HardwareType.Mainboard;
        }

        public IMeter ReadSensors(IList<ISensor> sensors)
        {
            // No sensors for the mobo
            return this;
        }

        public IMeter FormatMeters()
        {
            return this;
        }

        public void UpdateMeters(IList<ISensor> sensors)
        {
            // Nothing to update
        }
    }
}
