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
        public Computer GetAllHardware()
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
        /// The only hardware for testing
        /// </summary>
        /// <returns></returns>
        public Computer GetTestingHardware()
        {
            return new Computer
            {
                MainboardEnabled = true,
                CPUEnabled = false,
                RAMEnabled = false,
                GPUEnabled = true,
                FanControllerEnabled = false,
                HDDEnabled = false
            };
        }
    }
}
