﻿using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Mainboard;
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
        /// Return the observed Mainboard meters if enabled
        /// </summary>
        /// <returns></returns>
        MainboardMeters GetMainboardMeters();

        /// <summary>
        /// Return the observed CPU meters if enabled
        /// </summary>
        /// <returns></returns>
        CpuMeters GetCpuMeters();
    }
}