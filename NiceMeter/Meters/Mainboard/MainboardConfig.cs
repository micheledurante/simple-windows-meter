namespace NiceMeter.Meters.Mainboard
{
    /// <summary>
    /// Sensors for the Mainboard. This is mapped to OpenHardwareMonitor's internal sensor naming scheme
    /// </summary>
    public class MainboardConfig
    {
        public bool CpuVCore { get; set; }
        public bool CpuSoc { get; set; }
        public bool DRam { get; set; }
        public bool Vrm { get; set; }
        public bool TSensor { get; set; }
        public bool CpuFan { get; set; }
        public bool WPump { get; set; }

        public static MainboardConfig GetTestingMainboard()
        {
            return new MainboardConfig
            { 
                CpuVCore = false,
                CpuSoc = false,
                DRam = false,
                Vrm = false,
                TSensor = false,
                CpuFan = false,
                WPump = false
            };
        }
    }
}
