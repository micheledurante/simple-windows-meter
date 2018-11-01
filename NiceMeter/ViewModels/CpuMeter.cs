using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.ViewModels
{
    class CpuMeter : AbstractMeter, IMeter
    {
        private Unit power = null;

        public CpuMeter(string name)
        {
            Name = name;
            HardwareType = HardwareType.CPU;
        }

        public IMeter FilterSensors(IList<ISensor> sensors)
        {
            power = new Unit(sensors.Where(x => x.SensorType == SensorType.Power && x.Name.Contains("CPU Package")).First().Value, "W", "{0:N0}");
            return this;
        }

        public IMeter GetDisplayMeter()
        {
            Text = power.ToString();
            return this;
        }

        public void UpdateMeter(IList<ISensor> sensors)
        {
            power.Value = sensors.Where(x => x.SensorType == SensorType.Power && x.Name.Contains("CPU Package")).First().Value;
            Text = power.ToString();
        }
    }
}
