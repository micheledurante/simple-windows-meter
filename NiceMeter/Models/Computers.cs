using OpenHardwareMonitor.Hardware;

/// <summary>
/// Defines an OpenHardwareMonitor Computer with all sensors enabled
/// </summary>
namespace NiceMeter.Models
{
    /// <summary>
    /// Defines the device settings to use for measurements
    /// </summary>
    public class Computers
    {
        /// <summary>
        /// Default computer, all hardware is enabled
        /// </summary>
        /// <returns></returns>
        public Computer GetDefault()
        {
            return new Computer
            {
                MainboardEnabled = true,
                CPUEnabled = true,
                RAMEnabled = true,
                GPUEnabled = true,
                FanControllerEnabled = true,
                HDDEnabled = true
            };
        }

        /// <summary>
        /// A sample computer settings used during development
        /// </summary>
        /// <returns></returns>
        public Computer GetTesting()
        {
            return new Computer
            {
                MainboardEnabled = true,
                CPUEnabled = true,
                RAMEnabled = false,
                GPUEnabled = false,
                FanControllerEnabled = false,
                HDDEnabled = false
            };
        }
    }
}
