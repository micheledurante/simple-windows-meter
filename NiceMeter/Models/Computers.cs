namespace NiceMeter.Models
{
    /// <summary>
    /// Define an OpenHardwareMonitor Computer with all sensors enabled
    /// </summary>
    public class Computers
    {
        /// <summary>
        /// The computer as defined in the settings file
        /// </summary>
        /// <returns></returns>
        public ComputerModel GetHardware()
        {
            var config = new HardwareConfig();
            
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
