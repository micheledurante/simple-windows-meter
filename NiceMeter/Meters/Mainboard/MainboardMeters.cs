using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace NiceMeter.Meters.Mainboard
{
    /// <summary>
    /// 
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

        public MainboardMeters(string name)
        {
            Name = name;
            HardwareType = HardwareType.Mainboard;
        }

        public override IMeter ReadSensors(IHardware hardware)
        {
            CpuFan.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == "Fan Control #2").First().Value;
            return this;
        }

        public override IMeter FormatMeters()
        {
            return this;
        }

        public override void UpdateMeters(IHardware hardware)
        {
            CpuFan.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == "Fan Control #2").First().Value;
            Text = string.Format("{0}", CpuFan.Convert().GetTextBlock().Text);
        }
    }
}
