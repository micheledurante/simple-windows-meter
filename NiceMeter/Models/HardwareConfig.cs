namespace NiceMeter.Models
{
    /// <summary>
    /// Encapsulate user settings for enabling hardware
    /// </summary>
    public class HardwareConfig
    {
        public bool MainboardEnabled { get; set; } = Properties.NiceMeter.Default.MainboardEnabled;
        public bool CPUEnabled { get; set; } = Properties.NiceMeter.Default.CpuEnabled;
        public bool RAMEnabled { get; set; } = Properties.NiceMeter.Default.RamEnabled;
        public bool GPUEnabled { get; set; } = Properties.NiceMeter.Default.GpuEnabled;
        public bool FanControllerEnabled { get; set; } = Properties.NiceMeter.Default.FanControllerEnabled;
        public bool HDDEnabled { get; set; } = Properties.NiceMeter.Default.HddEnabled;
    }
}
