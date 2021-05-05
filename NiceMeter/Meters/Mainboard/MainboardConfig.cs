namespace NiceMeter.Meters.Mainboard
{
    /// <summary>
    /// Sensors for the Mainboard and its Sub Hardware. This will map to OpenHardwareMonitor's internal sensor naming scheme
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

        public static MainboardConfig GetCrosshair8Mainboard()
        {
            return new MainboardConfig // ASUS ROG CROSSHAIR VIII IMPACT
            { 
                CpuVCore = true,
                CpuSoc = true,
                DRam = true,
                Vrm = true,
                TSensor = true,
                CpuFan = true,
                WPump = true
            };
        }

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
