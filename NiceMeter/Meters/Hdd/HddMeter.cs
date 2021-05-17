using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Hdd
{
    public class HddMeter : AbstractMeter
    {
        public const string DefaultMeterName = "Disk";
        public IUnit UsedSpace { get; set; } = new PercentUnit("Used Space", "Used", null);
        public IList<IUnit> Units { get; set; } = new List<IUnit>();

        public HddMeter() : base(DefaultMeterName, HardwareType.HDD)
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
