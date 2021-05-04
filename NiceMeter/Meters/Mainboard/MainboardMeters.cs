using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Mainboard
{
    /// <summary>
    /// Represent the collection of information for the Mainboard
    /// </summary>
    class MainboardMeters : AbstractMeter
    {
        public VoltUnit CpuVCore { get; set; } = new VoltUnit("CPU VCore", 0);
        public VoltUnit CpuSoc { get; set; } = new VoltUnit("CPU SOC", 0);
        public VoltUnit DRam { get; set; } = new VoltUnit("DRAM", 0);
        public TempUnit Vrm { get; set; } = new TempUnit("VRM", 0);
        public TempUnit TSensor { get; set; } = new TempUnit("T_Sensor", 0);
        public RpmUnit CpuFan { get; set; } = new RpmUnit("CPU Fan", 0);
        public RpmUnit WPump { get; set; } = new RpmUnit("W_PUMP", 0);

        public IDictionary<string, IUnit> Units { get; set; } = new Dictionary<string, IUnit>();

        public MainboardMeters(string name, MainboardConfig config) : base(name, HardwareType.Mainboard)
        {
            if (config.CpuVCore)
            {
                Units.Add("CpuVCore", CpuVCore);
            }

            if (config.CpuSoc)
            {
                Units.Add("CpuSoc", CpuSoc);
            }

            if (config.DRam)
            {
                Units.Add("DRam", DRam);
            }

            if (config.Vrm)
            {
                Units.Add("Vrm", Vrm);
            }

            if (config.TSensor)
            {
                Units.Add("TSensor", TSensor);
            }

            if (config.CpuFan)
            {
                Units.Add("CpuFan", CpuFan);
            }

            if (config.WPump)
            {
                Units.Add("WPump", WPump);
            }
        }

        public override void ReadSensors(IHardware hardware)
        {
            if (Units.ContainsKey("CpuFan"))
            {
                CpuFan.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == "Fan Control #2").First().Value;
            }
        }

        public override void UpdateMeters(IHardware hardware)
        {
            ReadSensors(hardware);

            Text = string.Format("{0}", CpuFan.ToString());
        }
    }
}
