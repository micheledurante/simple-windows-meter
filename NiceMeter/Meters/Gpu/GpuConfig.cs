namespace NiceMeter.Meters.Gpu
{
    /// <summary>
    /// Sensors for the GPU. This will be mapped to OpenHardwareMonitor's internal sensor naming scheme
    /// </summary>
    public class GpuConfig
    {
        public bool GpuCore { get; set; } = Properties.NiceMeter.Default.GpuCore;
        public bool GpuMemory { get; set; } = Properties.NiceMeter.Default.GpuMemory;
        public bool GpuShader { get; set; } = Properties.NiceMeter.Default.GpuShader;
        public bool GpuCoreLoad { get; set; } = Properties.NiceMeter.Default.GpuCoreLoad;
        public bool GpuTemp { get; set; } = Properties.NiceMeter.Default.GpuTemp;
        public bool GpuMemoryLoad { get; set; } = Properties.NiceMeter.Default.GpuMemoryLoad;
        public bool GpuMemoryTotal { get; set; } = Properties.NiceMeter.Default.GpuMemoryTotal;
        public bool GpuMemoryUsed { get; set; } = Properties.NiceMeter.Default.GpuMemoryUsed;
        public bool GpuMemoryFree { get; set; } = Properties.NiceMeter.Default.GpuMemoryFree;
    }
}
