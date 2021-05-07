using OpenHardwareMonitor.Hardware;

namespace NiceMeter.Meters.Mainboard
{
    /// <summary>
    /// Represent the collection of information for the Mainboard
    /// </summary>
    public class MainboardMeter : AbstractMeter
    {
        /// <summary>
        /// Collection of the Sub Hardware sensors
        /// </summary>
        public MainboardSubHardwareMeter SubHardware { get; set; }

        public MainboardMeter(string name, MainboardConfig config) : base(name, HardwareType.Mainboard)
        {
            // The Mainboard does not seem to have sensors as these are provided by the Sub Hardare
            SubHardware = new MainboardSubHardwareMeter("", config);
        }

        public override IMeter ReadSensors(IHardware hardware)
        {
            SubHardware.ReadSensors(hardware);
            return this;
        }

        public override void UpdateMeters(IHardware hardware)
        {
            SubHardware.UpdateMeters(hardware);

            Text = string.Format(
                "{0} {1} {2} {3} {4} {5} {6}", 
                SubHardware.CpuVCore.ToString(), 
                SubHardware.CpuSoc.ToString(),
                SubHardware.DRam.ToString(),
                SubHardware.Vrm.ToString(),
                SubHardware.TSensor.ToString(),
                SubHardware.CpuFan.ToString(),
                SubHardware.WPump.ToString()
            );
        }
    }
}
