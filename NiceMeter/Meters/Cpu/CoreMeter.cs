using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Cpu
{
    class CoreMeter : AbstractMeter
    {
        private Unit load = null;
        private Unit temp = null;
        private Unit freq = null;

        public CoreMeter(string name)
        {
            Name = name;
            HardwareType = HardwareType.CPU;
        }

        public override IMeter ReadSensors(IHardware hardware)
        {
            load = new Unit("", hardware.Sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Load).First().Value, "%", "{0:N0}");  
            freq = new Unit("", hardware.Sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Clock).First().Value / 1000, "GHz", "{0:N2}");
            temp = new Unit("", hardware.Sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Temperature).First().Value, "°C", "{0:N0}");
            return this;
        }

        public override IMeter FormatMeters()
        {
            Text = string.Format("{0}, {1}, @{2}", load.Convert().GetTextBlock().Text, temp.Convert().GetTextBlock().Text, freq.Convert().GetTextBlock().Text);
            return this;
        }

        public override void UpdateMeters(IHardware hardware)
        {
            load.Value = hardware.Sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Load).First().Value;
            freq.Value = hardware.Sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Clock).First().Value / 1000;
            temp.Value = hardware.Sensors.Where(x => x.Name == Name && x.SensorType == SensorType.Temperature).First().Value;
            Text = string.Format("{0}, {1}, @{2}", load.Convert().GetTextBlock().Text, temp.Convert().GetTextBlock().Text, freq.Convert().GetTextBlock().Text);
        }
    }
}
