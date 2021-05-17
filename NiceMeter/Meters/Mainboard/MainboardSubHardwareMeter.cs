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
        public IUnit CpuVCore { get; set; } = new VoltUnit("CPU VCore", "CPU Core", null);
        public IUnit CpuSoc { get; set; } = new VoltUnit("Voltage #7", "SOC", null);
        public IUnit DRam { get; set; } = new VoltUnit("Voltage #14", "DRAM", null);
        public IUnit Vrm { get; set; } = new TempUnit("Temperature #2", "T VRM", null);
        public IUnit TSensor { get; set; } = new TempUnit("Temperature #6", "T H2O", null);
        public IUnit CpuFan { get; set; } = new RpmUnit("Fan #2", "CPU Fan", null);
        public IUnit WPump { get; set; } = new RpmUnit("Fan #6", "Pump", null);
        public IList<IUnit> Units { get; set; } = new List<IUnit>();

        public MainboardSubHardwareMeter(string name, MainboardConfig config) : base(name, HardwareType.SuperIO)
        {
            if (config.MainboardCpuVCore)
            {
                Units.Add(CpuVCore);
            }

            if (config.MainboardCpuSoc)
            {
                Units.Add(CpuSoc);
            }

            if (config.MainboardDRam)
            {
                Units.Add(DRam);
            }

            if (config.MainboardVrm)
            {
                Units.Add(Vrm);
            }

            if (config.MainboardTSensor)
            {
                Units.Add(TSensor);
            }

            if (config.MainboardCpuFan)
            {
                Units.Add(CpuFan);
            }

            if (config.MainboardWPump)
            {
                Units.Add(WPump);
            }
        }

        public override IMeter ReadSensors(IHardware hardware)
        {
            foreach (var unit in Units)
            {
                unit.Value = hardware.SubHardware[0].Sensors.Where(x => x.Name == unit.OHName).FirstOrDefault()?.Value;
            }

            return this;
        }

        public override void UpdateMeters(IHardware hardware)
        {
            ReadSensors(hardware);
        }
    }
}
