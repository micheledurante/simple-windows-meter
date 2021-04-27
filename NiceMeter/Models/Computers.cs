namespace NiceMeter.Models
{
    /// <summary>
    /// Define an OpenHardwareMonitor Computer with all sensors enabled
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
        /// Simple hardware only for testing
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
