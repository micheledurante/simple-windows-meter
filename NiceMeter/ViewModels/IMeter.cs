using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace NiceMeter.Visitors
{
    public interface IMeter
    {
        /// <summary>
        /// Read the sensor values, Implement logic for specific sub-types (mainboard, cpus, etc...)
        /// </summary>
        /// <param name="sensors"></param>
        /// <returns></returns>
        IMeter ReadSensors(IList<ISensor> sensors);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IMeter FormatMeters();

        HardwareType GetHardwareType();

        void UpdateMeters(IList<ISensor> sensors);
    }
}
