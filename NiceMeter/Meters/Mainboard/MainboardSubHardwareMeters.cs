using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Mainboard
{
    /// <summary>
    /// Represent the collection of information for the Mainboard Sub Hardware
    /// </summary>
    public class MainboardSubHardwareMeters : AbstractMeter
    {
        public VoltUnit CpuVCore { get; set; } = new VoltUnit("CPU VCore", "CPU VCore", 0);
        public VoltUnit CpuSoc { get; set; } = new VoltUnit("Voltage #7", "CPU SOC", 0);
        public VoltUnit DRam { get; set; } = new VoltUnit("Voltage #14", "DRAM", 0);
        public TempUnit Vrm { get; set; } = new TempUnit("Temperature #2", "VRM", 0);
        public TempUnit TSensor { get; set; } = new TempUnit("Temperature #6", "T_Sensor", 0);
        public RpmUnit CpuFan { get; set; } = new RpmUnit("Fan #2", "CPU Fan", 0);
        public RpmUnit WPump { get; set; } = new RpmUnit("Fan #6", "W_PUMP", 0);
        public IDictionary<string, IUnit> Units { get; set; } = new Dictionary<string, IUnit>();

        public MainboardSubHardwareMeters(string name, MainboardConfig config) : base(name, HardwareType.SuperIO)
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

        public override void ReadSensors(IHardware hardware)
        {
            if (Units.ContainsKey(CpuVCore.Label))
            {
                CpuVCore.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == CpuVCore.OHName).First().Value;
            }

            if (Units.ContainsKey(CpuSoc.Label))
            {
                CpuSoc.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == CpuSoc.OHName).First().Value;
            }

            if (Units.ContainsKey(DRam.Label))
            {
                DRam.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == DRam.OHName).First().Value;
            }

            if (Units.ContainsKey(Vrm.Label))
            {
                Vrm.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == Vrm.OHName).First().Value;
            }

            if (Units.ContainsKey(TSensor.Label))
            {
                TSensor.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == TSensor.OHName).First().Value;
            }

            if (Units.ContainsKey(CpuFan.Label))
            {
                CpuFan.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == CpuFan.OHName).First().Value;
            }

            if (Units.ContainsKey(WPump.Label))
            {
                WPump.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == WPump.OHName).First().Value;
            }
        }

        public override void UpdateMeters(IHardware hardware)
        {
            ReadSensors(hardware);
        }
    }
}
