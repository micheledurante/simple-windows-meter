using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Ram
{
    public class RamMeter : AbstractMeter
    {
        public const string DefaultMeterName = "RAM";
        public RamGbUnit AvailableMemory { get; set; } = new RamGbUnit("Available Memory", "Available", null);
        public RamGbUnit UsedMemory { get; set; } = new RamGbUnit("Used Memory", "Used", null);
        public RamPercentUnit Memory { get; set; } = new RamPercentUnit("Memory", "Memory", null);
        public IList<Unit> Units { get; set; } = new List<Unit>();

        public RamMeter() : base(DefaultMeterName, HardwareType.RAM)
        {
            // No on/off is needed as RAM is not optional in a computer! If enabled, these values are to be expected
            Units.Add(AvailableMemory);
            Units.Add(UsedMemory);
            Units.Add(Memory);
        }

        public override IMeter ReadSensors(IHardware hardware)
        {
            foreach (var unit in Units)
            {
                unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName).FirstOrDefault()?.Value;
            }

            return this;
        }

        public override void UpdateMeters(IHardware hardware)
        {
            ReadSensors(hardware);

            Text = string.Format(
                "{0} ({1})",
                UsedMemory.ToString(),
                Memory.ToString()
            );
        }
    }
}
