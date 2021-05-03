using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace NiceMeter.Meters.Cpu
{
    class CpuMeter : AbstractMeter
    {
        private Unit power = null;
        private Unit load = null;

        public CpuMeter(string name)
        {
            Name = name;
            HardwareType = HardwareType.CPU;
        }

        public override IMeter ReadSensors(IHardware hardware)
        {
            power = new Unit("", hardware.Sensors.Where(x => x.SensorType == SensorType.Power && x.Name.Contains("CPU Package")).First().Value, "W", "{0:N0}");
            load = new Unit("", hardware.Sensors.Where(x => x.SensorType == SensorType.Load && x.Name.Contains("CPU Total")).First().Value, "%", "{0:N0}");
            return this;
        }

        public override IMeter FormatMeters()
        {
            Text = string.Format("{0}, {1}", load.Convert().GetTextBlock().Text, power.Convert().GetTextBlock().Text);
            return this;
        }

        public override void UpdateMeters(IHardware hardware)
        {
            power.Value = hardware.Sensors.Where(x => x.SensorType == SensorType.Power && x.Name.Contains("CPU Package")).First().Value;
            load.Value = hardware.Sensors.Where(x => x.SensorType == SensorType.Load && x.Name.Contains("CPU Total")).First().Value;
            Text = string.Format("{0}, {1}", load.Convert().GetTextBlock().Text, power.Convert().GetTextBlock().Text);
        }
    }
}
