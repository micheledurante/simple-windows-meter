using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Gpu
{
    public class GpuMeter : AbstractMeter
    {
        public FreqUnit GpuCore { get; set; } = new FreqUnit("GPU Core", "Core", null);
        public FreqUnit GpuMemory { get; set; } = new FreqUnit("GPU Memory", "Memory", null);
        public FreqUnit GpuShader { get; set; } = new FreqUnit("GPU Shader", "Shader", null);
        public PercentUnit GpuCoreLoad { get; set; } = new PercentUnit("GPU Core", "Load", null);
        public TempUnit GpuTemp { get; set; } = new TempUnit("GPU Core", "Temp", null);
        public PercentUnit GpuMemoryLoad { get; set; } = new PercentUnit("GPU Memory", "VRAM", null);
        public GbUnit GpuMemoryTotal { get; set; } = new GbUnit("GPU Memory Total", "VRAM Total", null);
        public GbUnit GpuMemoryUsed { get; set; } = new GbUnit("GPU Memory Used", "VRAM Used", null);
        public GbUnit GpuMemoryFree { get; set; } = new GbUnit("GPU Memory Free", "VRAM Free", null);

        public IList<Unit> Units { get; set; } = new List<Unit>();

        public GpuMeter(string name, HardwareType hardwareType, GpuConfig config) : base(name, hardwareType)
        {
            if (config.GpuCore)
            {
                Units.Add(GpuCore);
            }

            if (config.GpuMemory)
            {
                Units.Add(GpuMemory);
            }

            if (config.GpuShader)
            {
                Units.Add(GpuShader);
            }

            if (config.GpuCoreLoad)
            {
                Units.Add(GpuCoreLoad);
            }

            if (config.GpuTemp)
            {
                Units.Add(GpuTemp);
            }

            if (config.GpuMemoryLoad)
            {
                Units.Add(GpuMemoryLoad);
            }

            if (config.GpuMemoryTotal)
            {
                Units.Add(GpuMemoryTotal);
            }

            if (config.GpuMemoryUsed)
            {
                Units.Add(GpuMemoryUsed);
            }

            if (config.GpuMemoryFree)
            {
                Units.Add(GpuMemoryFree);
            }
        }

        public override IMeter ReadSensors(IHardware hardware)
        {
            foreach (var unit in Units)
            {
                if (unit.Label == GpuCore.Label)
                {
                    unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName && x.SensorType == SensorType.Clock).FirstOrDefault()?.Value / 1000;
                }
                else if (unit.Label == GpuMemory.Label)
                {
                    unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName && x.SensorType == SensorType.Clock).FirstOrDefault()?.Value / 1000;
                }
                else if (unit.Label == GpuShader.Label)
                {
                    unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName && x.SensorType == SensorType.Clock).FirstOrDefault()?.Value / 1000;
                }
                else if (unit.Label == GpuCoreLoad.Label)
                {
                    unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName && x.SensorType == SensorType.Load).FirstOrDefault()?.Value;
                }
                else if (unit.Label == GpuMemoryLoad.Label)
                {
                    unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName && x.SensorType == SensorType.Load).FirstOrDefault()?.Value;
                }
                else if (unit.Label == GpuMemoryTotal.Label)
                {
                    unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName && x.SensorType == SensorType.Load).FirstOrDefault()?.Value / 1000;
                }
                else if (unit.Label == GpuMemoryUsed.Label)
                {
                    unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName && x.SensorType == SensorType.Load).FirstOrDefault()?.Value / 1000;
                }
                else if (unit.Label == GpuMemoryFree.Label)
                {
                    unit.Value = hardware.Sensors.Where(x => x.Name == unit.OHName && x.SensorType == SensorType.Load).FirstOrDefault()?.Value / 1000;
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
                GpuCore.ToString(),
                GpuCoreLoad.ToString(),
                GpuTemp.ToString(),
                GpuMemoryLoad.ToString()
            );
        }
    }
}
