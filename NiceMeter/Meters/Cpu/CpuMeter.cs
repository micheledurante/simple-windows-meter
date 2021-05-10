using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Cpu
{
    public class CpuMeter : AbstractMeter
    {
        public PercentUnit CpuTotal { get; set; } = new PercentUnit("CPU Total", "Load", null);
        public WattUnit CpuPackage { get; set; } = new WattUnit("CPU Package", "Power", null);
        public TempUnit CpuTemp { get; set; } = new TempUnit("CPU", "T", null);
        public FreqUnit CpuClock { get; set; } = new FreqUnit("CPU", "Clock", null); // Will be an average of each core's frequency

        public IList<Unit> Units { get; set; } = new List<Unit>();

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
                else if (unit.Label == CpuTemp.Label)
                {
                    unit.Value = hardware.Sensors
                        .Where(x => x.Name.Contains(CpuTemp.OHName) && x.SensorType == SensorType.Temperature)
                        .Select(x => x.Value)
                        .Average();
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
                Text = null;
                return;
            }

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
