using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Meters.Gpu
{
    public class GpuMeter : AbstractMeter
    {
        public const string GPU_CORE_OHNAME = "GPU Core";
        public const string GPU_MEMORY_OHNAME = "GPU Memory";
        public const string GPU_SHADER_OHNAME = "GPU Shader";
        public const string GPU_CORE_LOAD_OHNAME = "GPU Core";
        public const string GPU_TEMP_OHNAME = "GPU Core";
        public const string GPU_MEMORY_LOAD_OHNAME = "GPU Memory";
        public const string GPU_MEMORY_TOTAL_OHNAME = "GPU Memory Total";
        public const string GPU_MEMORY_USED_OHNAME = "GPU Memory Used";
        public const string GPU_MEMORY_FREE_OHNAME = "GPU Memory Free";

        public IUnit GpuCore { get; set; } = new FreqUnit(GPU_CORE_OHNAME, "Core", null);
        public IUnit GpuMemory { get; set; } = new FreqUnit(GPU_MEMORY_OHNAME, "Memory", null);
        public IUnit GpuShader { get; set; } = new FreqUnit(GPU_SHADER_OHNAME, "Shader", null);
        public IUnit GpuCoreLoad { get; set; } = new PercentUnit(GPU_CORE_LOAD_OHNAME, "Load", null);
        public IUnit GpuTemp { get; set; } = new TempUnit(GPU_TEMP_OHNAME, "Temp", null);
        public IUnit GpuMemoryLoad { get; set; } = new PercentUnit(GPU_MEMORY_LOAD_OHNAME, "VRAM", null);
        public IUnit GpuMemoryTotal { get; set; } = new GbUnit(GPU_MEMORY_TOTAL_OHNAME, "VRAM Total", null);
        public IUnit GpuMemoryUsed { get; set; } = new GbUnit(GPU_MEMORY_USED_OHNAME, "VRAM Used", null);
        public IUnit GpuMemoryFree { get; set; } = new GbUnit(GPU_MEMORY_FREE_OHNAME, "VRAM Free", null);

        public IList<IUnit> Units { get; set; } = new List<IUnit>();

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
                return;
            }

            ReadSensors(hardware);

            Text = FormatUnits(Units);
        }
    }
}
