namespace NiceMeter.Meters.Mainboard
{
    /// <summary>
    /// Sensors for the Mainboard and its Sub Hardware. This will be mapped to OpenHardwareMonitor's internal sensor naming scheme
    /// </summary>
    public class MainboardConfig
    {
        public bool MainboardCpuVCore { get; set; } = Properties.NiceMeter.Default.MainboardCpuVCore;
        public bool MainboardCpuSoc { get; set; } = Properties.NiceMeter.Default.MainboardCpuSoc;
        public bool MainboardDRam { get; set; } = Properties.NiceMeter.Default.MainboardDRam;
        public bool MainboardVrm { get; set; } = Properties.NiceMeter.Default.MainboardVrm;
        public bool MainboardTSensor { get; set; } = Properties.NiceMeter.Default.MainboardTSensor;
        public bool MainboardCpuFan { get; set; } = Properties.NiceMeter.Default.MainboardCpuFan;
        public bool MainboardWPump { get; set; } = Properties.NiceMeter.Default.MainboardWPump;
    }
}
