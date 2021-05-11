using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Mainboard;
using NiceMeter.Meters.Ram;
using NiceMeter.Models;
using System.Collections.ObjectModel;

namespace NiceMeter.Meters
{
    public interface IObservableMeters
    {
        /// <summary>
        /// Return the stored collection of meters
        /// </summary>
        /// <returns></returns>
        ObservableCollection<IMeter> GetMeters();

        /// <summary>
        /// Get the stored hardware configuration for the computer
        /// </summary>
        /// <returns></returns>
        HardwareConfig GetHardwareConfig();

        /// <summary>
        /// Return the observed Mainboard meters, if enabled
        /// </summary>
        /// <returns></returns>
        MainboardMeter GetMainboardMeter();

        /// <summary>
        /// Return the observed CPU meters, if enabled
        /// </summary>
        /// <returns></returns>
        CpuMeter GetCpuMeter();

        /// <summary>
        /// Return the observed RAM meters, if enabled
        /// </summary>
        /// <returns></returns>
        RamMeter GetRamMeter();
    }
}
