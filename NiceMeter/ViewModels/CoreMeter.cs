using NiceMeter.Meter;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.ViewModels
{
    class CoreMeter : AbstractMeter, IMeter
    {
        private Unit load = null;
        private Unit temp = null;
        private Unit freq = null;

        public CoreMeter(string name)
        {
            Name = name;
            HardwareType = HardwareType.CPU;
        }

        public IMeter FilterSensors(IList<ISensor> sensors)
        {
            load = new Unit(sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Load).First().Value, "%", "{0:N0}");  
            freq = new Unit(sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Clock).First().Value / 1000, "GHz", "{0:N2}");
            temp = new Unit(sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Temperature).First().Value, "°C", "{0:N0}");
            return this;
        }

        public IMeter GetDisplayMeter()
        {
            Text = string.Format("{0}, {1}, @{2}", load.ToString(), temp.ToString(), freq.ToString());
            return this;
        }

        public void UpdateMeter(IList<ISensor> sensors)
        {
            load.Value = sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Load).First().Value;
            freq.Value = sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Clock).First().Value / 1000;
            temp.Value = sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Temperature).First().Value;
            Text = string.Format("{0}, {1}, @{2}", load.ToString(), temp.ToString(), freq.ToString());
        }
    }
}
