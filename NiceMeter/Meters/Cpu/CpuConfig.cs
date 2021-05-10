namespace NiceMeter.Meters.Cpu
{
    /// <summary>
    /// Sensors for the CPU. This will map to OpenHardwareMonitor's internal sensor naming scheme
    /// </summary>
    public class CpuConfig
    {
        public bool CpuTotal { get; set; } = Properties.NiceMeter.Default.CpuTotal;
        public bool CpuPackage { get; set; } = Properties.NiceMeter.Default.CpuPackage;
        public bool CpuClock { get; set; } = Properties.NiceMeter.Default.CpuClock;
        public bool CpuTemp { get; set; } = Properties.NiceMeter.Default.CpuTemp;
    }
}
