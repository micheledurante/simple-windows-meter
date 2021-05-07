using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Mainboard
{
    /// <summary>
    /// Represent the collection of information for the Mainboard Sub Hardware
    /// </summary>
    public class MainboardSubHardwareMeter : AbstractMeter
    {
        public VoltUnit CpuVCore { get; set; } = new VoltUnit("CPU VCore", "Core", 0);
        public VoltUnit CpuSoc { get; set; } = new VoltUnit("Voltage #7", "SOC", 0);
        public VoltUnit DRam { get; set; } = new VoltUnit("Voltage #14", "DRAM", 0);
        public TempUnit Vrm { get; set; } = new TempUnit("Temperature #2", "T VRM", 0);
        public TempUnit TSensor { get; set; } = new TempUnit("Temperature #6", "T H2O", 0);
        public RpmUnit CpuFan { get; set; } = new RpmUnit("Fan #2", "CPU Fan", 0);
        public RpmUnit WPump { get; set; } = new RpmUnit("Fan #6", "PUMP", 0);
        public IDictionary<string, Unit> Units { get; set; } = new Dictionary<string, Unit>();

        public MainboardSubHardwareMeter(string name, MainboardConfig config) : base(name, HardwareType.SuperIO)
        {
            if (config.CpuVCore)
            {
                Units.Add(CpuVCore.Label, CpuVCore);
            }

            if (config.CpuSoc)
            {
                Units.Add(CpuSoc.Label, CpuSoc);
            }

            if (config.DRam)
            {
                Units.Add(DRam.Label, DRam);
            }

            if (config.Vrm)
            {
                Units.Add(Vrm.Label, Vrm);
            }

            if (config.TSensor)
            {
                Units.Add(TSensor.Label, TSensor);
            }

            if (config.CpuFan)
            {
                Units.Add(CpuFan.Label, CpuFan);
            }

            if (config.WPump)
            {
                Units.Add(WPump.Label, WPump);
            }
        }

        public override IMeter ReadSensors(IHardware hardware)
        {
            foreach (var unit in Units)
            {
                unit.Value.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == unit.Value.OHName).FirstOrDefault()?.Value;
            }

            return this;
        }

        public override void UpdateMeters(IHardware hardware)
        {
            ReadSensors(hardware);
        }
    }
}
