namespace NiceMeter.Meters.Cpu
{
    /// <summary>
    /// Sensors for the CPU. This will map to OpenHardwareMonitor's internal sensor naming scheme
    /// </summary>
    public class CpuConfig
    {
        public bool CpuTotal { get; set; }
        public bool CpuPackage { get; set; }
        public bool CpuClock { get; set; }
        public bool CpuTemp { get; set; }

        public static CpuConfig GetRyzen3Cpu()
        {
            return new CpuConfig
            {
                CpuTotal = true,
                CpuPackage = true,
                CpuClock = true,
                CpuTemp = true
            };
        }
    }
}
