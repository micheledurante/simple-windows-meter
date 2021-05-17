using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Cpu
{
    public class CpuMeter : AbstractMeter
    {
        public IUnit CpuTotal { get; set; } = new PercentUnit("CPU Total", "Load", null);
        public IUnit CpuPackage { get; set; } = new WattUnit("CPU Package", "Power", null);
        public IUnit CpuTemp { get; set; } = new TempUnit("CPU CCD Average", "T", null);
        public IUnit CpuClock { get; set; } = new FreqUnit("CPU", "Clock", null); // Will be an average of each core's frequency

        public IList<IUnit> Units { get; set; } = new List<IUnit>();

        public CpuMeter(string name, CpuConfig config) : base(name, HardwareType.CPU)
        {
            if (config.CpuTotal)
            {
                Units.Add(CpuTotal);
            }

            if (config.CpuPackage)
            {
                Units.Add(CpuPackage);
            }

            if (config.CpuTemp)
            {
                Units.Add(CpuTemp);
            }

            if (config.CpuClock)
            {
                Units.Add(CpuClock);
            }  
        }

        public override IMeter ReadSensors(IHardware hardware)
        {
            foreach (var unit in Units)
            {
                if (unit.Label == CpuClock.Label)
                {
                    unit.Value = hardware.Sensors
                        .Where(x => x.Name.Contains(CpuClock.OHName) && x.SensorType == SensorType.Clock)
                        .Select(x => x.Value)
                        .Average() / 1000;
                }
                else
                {
                    unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName).FirstOrDefault()?.Value;
                }
            }

            return this;
        }

        public override void UpdateMeters(IHardware hardware)
        {
            if (Units.Count == 0)
            {
                return;
            }

            ReadSensors(hardware);

            Text = FormatUnits(Units);
        }
    }
}
