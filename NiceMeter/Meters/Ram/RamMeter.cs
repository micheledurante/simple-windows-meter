using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Ram
{
    public class RamMeter : AbstractMeter
    {
        public const string DEFAULT_METER_NAME = "RAM";
        public const string AVAILABLE_MEMORY_OHNAME = "Available Memory";
        public const string USED_MEMORY_OHNAME = "Used Memory";
        public const string MEMORY_OHNAME = "Memory";

        public IUnit AvailableMemory { get; set; } = new RamGbUnit(AVAILABLE_MEMORY_OHNAME, "Available", null);
        public IUnit UsedMemory { get; set; } = new RamGbUnit(USED_MEMORY_OHNAME, "Used", null);
        public IUnit Memory { get; set; } = new RamPercentUnit(MEMORY_OHNAME, "Memory", null);
        public IList<IUnit> Units { get; set; } = new List<IUnit>();

        public RamMeter() : base(DEFAULT_METER_NAME, HardwareType.RAM)
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

            Text = FormatUnits(Units);
        }
    }
}
