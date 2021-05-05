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
        }

        public override void ReadSensors(IHardware hardware)
        {
            if (Units.ContainsKey(CpuTotal.Label))
            {
                CpuTotal.Value = hardware.Sensors.Where(x => x.Name == CpuTotal.OHName).First().Value;
            }

            if (Units.ContainsKey(CpuPackage.Label))
            {
                CpuPackage.Value = hardware.Sensors.Where(x => x.Name == CpuPackage.OHName).First().Value;
            }
        }

        public override void UpdateMeters(IHardware hardware)
        {
            ReadSensors(hardware);

            Text = string.Format(
                "{0} {1}",
                CpuTotal.ToString(), 
                CpuPackage.ToString()
            );
        }
    }
}
