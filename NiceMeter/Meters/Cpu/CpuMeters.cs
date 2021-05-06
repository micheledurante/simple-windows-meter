using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Cpu
{
    public class CpuMeters : AbstractMeter
    {
        public PercentUnit CpuTotal { get; set; } = new PercentUnit("CPU Total", "Load", 0);
        public WattUnit CpuPackage { get; set; } = new WattUnit("CPU Package", "Power", 0);
        public TempUnit CpuTemp { get; set; } = new TempUnit("CPU", "T", 0);
        public FreqUnit CpuClock { get; set; } = new FreqUnit("CPU", "Clock", 0); // Will be an average of each core's frequency

        public IDictionary<string, IUnit> Units { get; set; } = new Dictionary<string, IUnit>();

        public CpuMeters(string name, CpuConfig config) : base(name, HardwareType.CPU)
        {
            if (config.CpuTotal)
            {
                Units.Add(CpuTotal.Label, CpuTotal);
            }

            if (config.CpuPackage)
            {
                Units.Add(CpuPackage.Label, CpuPackage);
            }

            if (config.CpuClock)
            {
                Units.Add(CpuClock.Label, CpuClock);
            }

            if (config.CpuTemp)
            {
                Units.Add(CpuTemp.Label, CpuTemp);
            }
        }

        public override void ReadSensors(IHardware hardware)
        {
            if (Units.ContainsKey(CpuTotal.Label))
            {
                CpuTotal.Value = hardware.Sensors.Where(x => x.Name == CpuTotal.OHName).FirstOrDefault()?.Value;
            }

            if (Units.ContainsKey(CpuPackage.Label))
            {
                CpuPackage.Value = hardware.Sensors.Where(x => x.Name == CpuPackage.OHName).FirstOrDefault()?.Value;
            }

            if (Units.ContainsKey(CpuClock.Label))
            {
                CpuClock.Value = hardware.Sensors
                    .Where(x => x.Name.Contains(CpuClock.OHName) && x.SensorType == SensorType.Clock)
                    .Select(x => x.Value)
                    .Average() / 1000;
            }

            if (Units.ContainsKey(CpuTemp.Label))
            {
                CpuTemp.Value = hardware.Sensors
                    .Where(x => x.Name.Contains(CpuTemp.OHName) && x.SensorType == SensorType.Temperature)
                    .Select(x => x.Value)
                    .Average();
            }
        }

        public override void UpdateMeters(IHardware hardware)
        {
            ReadSensors(hardware);

            Text = string.Format(
                "{0} {1} {2} {3}",
                CpuClock.ToString(),
                CpuTemp.ToString(),
                CpuTotal.ToString(), 
                CpuPackage.ToString()     
            );
        }
    }
}
