using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Cpu
{
    class CpuMeters : AbstractMeter
    {
        public PercentUnit CpuTotal { get; set; } = new PercentUnit("Cpu Total", 0);
        public WattUnit CpuPackage { get; set; } = new WattUnit("Cpu Package", 0);

        public IDictionary<string, IUnit> Units { get; set; } = new Dictionary<string, IUnit>();

        public CpuMeters(string name, CpuConfig config) : base(name, HardwareType.CPU)
        {
            if (config.CpuTotal)
            {
                Units.Add("CpuTotal", CpuTotal);
            }

            if (config.CpuPackage)
            {
                Units.Add("CpuPackage", CpuPackage);
            }
        }

        public override void ReadSensors(IHardware hardware)
        {
            if (Units.ContainsKey("CpuTotal"))
            {
                CpuTotal.Value = hardware.Sensors.Where(x => x.Name.Contains("CPU Total")).First().Value;
            }

            if (Units.ContainsKey("CpuPackage"))
            {
                CpuPackage.Value = hardware.Sensors.Where(x => x.Name.Contains("CPU Package")).First().Value;
            }
        }

        public override void UpdateMeters(IHardware hardware)
        {
            ReadSensors(hardware);

            Text = string.Format("{0} {1}", CpuTotal.ToString(), CpuPackage.ToString());
        }
    }
}
