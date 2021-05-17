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
        public const string MAINBOARD_CPU_V_CORE_OHNAME = "CPU VCore";
        public const string MAINBOARD_CPU_SOC_OHNAME = "Voltage #7";
        public const string MAINBOARD_D_RAM_OHNAME = "Voltage #14";
        public const string MAINBOARD_VRM_OHNAME = "Temperature #2";
        public const string MAINBOARD_T_SENSOR_OHNAME = "Temperature #6";
        public const string MAINBOARD_CPU_FAN_OHNAME = "Fan #2";
        public const string MAINBOARD_W_PUMP_OHNAME = "Fan #6";

        public IUnit CpuVCore { get; set; } = new VoltUnit(MAINBOARD_CPU_V_CORE_OHNAME, "CPU Core", null);
        public IUnit CpuSoc { get; set; } = new VoltUnit(MAINBOARD_CPU_SOC_OHNAME, "SOC", null);
        public IUnit DRam { get; set; } = new VoltUnit(MAINBOARD_D_RAM_OHNAME, "DRAM", null);
        public IUnit Vrm { get; set; } = new TempUnit(MAINBOARD_VRM_OHNAME, "T VRM", null);
        public IUnit TSensor { get; set; } = new TempUnit(MAINBOARD_T_SENSOR_OHNAME, "T H2O", null);
        public IUnit CpuFan { get; set; } = new RpmUnit(MAINBOARD_CPU_FAN_OHNAME, "CPU Fan", null);
        public IUnit WPump { get; set; } = new RpmUnit(MAINBOARD_W_PUMP_OHNAME, "Pump", null);

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
                unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName).FirstOrDefault()?.Value;
            }

            return this;
        }

        public override void UpdateMeters(IHardware hardware)
        {
            ReadSensors(hardware);
        }
    }
}
