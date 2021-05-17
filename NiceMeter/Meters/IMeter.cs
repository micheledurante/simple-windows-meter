using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace NiceMeter.Meters
{
    public interface IMeter
    {
        string Name { get; set; }

        HardwareType HardwareType { get; set; }

        /// <summary>
        /// Read the sensor values, Implement logic for specific sub-types (mainboard, cpus, etc...)
        /// </summary>
        /// <param name="hardware"></param>
        /// <returns></returns>
        IMeter ReadSensors(IHardware hardware);

        HardwareType GetHardwareType();

        void UpdateMeters(IHardware hardware);

        /// <summary>
        /// Format units for display 
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        string FormatUnits(IList<IUnit> units);
    }
}
