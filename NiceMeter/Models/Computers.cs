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
        public ComputerModel GetAllHardware()
        {
            var config = HardwareConfig.AllHardwareConfig();
            
            return new ComputerModel
            {
                MainboardEnabled = config.MainboardEnabled,
                CPUEnabled = config.CPUEnabled,
                RAMEnabled = config.RAMEnabled,
                GPUEnabled = config.GPUEnabled,
                FanControllerEnabled = config.FanControllerEnabled,
                HDDEnabled = config.HDDEnabled
            };
        }

        /// <summary>
        /// Simple hardware only for testing
        /// </summary>
        /// <returns></returns>
        public ComputerModel GetTestingHardware()
        {
            var config = HardwareConfig.TestingHardwareConfig();

            return new ComputerModel
            {
                MainboardEnabled = config.MainboardEnabled,
                CPUEnabled = config.CPUEnabled,
                RAMEnabled = config.RAMEnabled,
                GPUEnabled = config.GPUEnabled,
                FanControllerEnabled = config.FanControllerEnabled,
                HDDEnabled = config.HDDEnabled
            };
        }
    }
}
