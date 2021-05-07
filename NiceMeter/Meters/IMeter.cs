using OpenHardwareMonitor.Hardware;

namespace NiceMeter.Meters
{
    public interface IMeter
    {
        /// <summary>
        /// Read the sensor values, Implement logic for specific sub-types (mainboard, cpus, etc...)
        /// </summary>
        /// <param name="hardware"></param>
        /// <returns></returns>
        IMeter ReadSensors(IHardware hardware);

        HardwareType GetHardwareType();

        void UpdateMeters(IHardware hardware);
    }
}
