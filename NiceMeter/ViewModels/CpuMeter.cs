using NiceMeter.Meter;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.ViewModels
{
    class CpuMeter : AbstractMeter, IMeter
    {
        private Unit power = null;
        private Unit load = null;

        public CpuMeter(string name)
        {
            Name = name;
            HardwareType = HardwareType.CPU;
        }

        public IMeter FilterSensors(IList<ISensor> sensors)
        {
            power = new Unit(sensors.Where(x => x.SensorType == SensorType.Power && x.Name.Contains("CPU Package")).First().Value, "W", "{0:N0}");
            load = new Unit(sensors.Where(x => x.SensorType == SensorType.Load && x.Name.Contains("CPU Total")).First().Value, "%", "{0:N0}");
            return this;
        }

        public IMeter GetDisplayMeter()
        {
            Text = string.Format("{0}, {1}", load.ToString(), power.ToString());
            return this;
        }

        public void UpdateMeter(IList<ISensor> sensors)
        {
            power.Value = sensors.Where(x => x.SensorType == SensorType.Power && x.Name.Contains("CPU Package")).First().Value;
            load.Value = sensors.Where(x => x.SensorType == SensorType.Load && x.Name.Contains("CPU Total")).First().Value;
            Text = string.Format("{0}, {1}", load.ToString(), power.ToString());
        }
    }
}
