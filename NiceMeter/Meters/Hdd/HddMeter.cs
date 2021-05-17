using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Hdd
{
    public class HddMeter : AbstractMeter
    {
        public const string DEFAULT_METER_NAME = "Disk";
        public const string USED_SPACE_OHNAME = "Used Space";

        public IUnit UsedSpace { get; set; } = new PercentUnit(USED_SPACE_OHNAME, "Used", null);
        public IList<IUnit> Units { get; set; } = new List<IUnit>();

        public HddMeter() : base(DEFAULT_METER_NAME, HardwareType.HDD)
        {
            // No on/off is needed as RAM is not optional in a computer! If enabled, these values are to be expected
            Units.Add(UsedSpace);
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
