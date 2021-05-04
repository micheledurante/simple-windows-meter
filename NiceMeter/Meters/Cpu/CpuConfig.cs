namespace NiceMeter.Meters.Cpu
{
    /// <summary>
    /// Sensors for the CPU. This is mapped to OpenHardwareMonitor's internal sensor naming scheme
    /// </summary>
    public class CpuConfig
    {
        public bool CpuTotal { get; set; }
        public bool CpuPackage { get; set; }

        public static CpuConfig GetTestingCpu()
        {
            return new CpuConfig
            {
                CpuTotal = true,
                CpuPackage = true
            };
        }
    }
}
