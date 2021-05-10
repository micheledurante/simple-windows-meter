﻿using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Mainboard;
using NiceMeter.Models;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace NiceMeter.Meters
{
    /// <summary>
    /// Represent the collection of meters observed for changes on every tick cycle
    /// </summary>
    public class ObservableMeters : IObservableMeters
    {
        public readonly HardwareConfig hardwareConfig;
        private readonly ObservableCollection<IMeter> meters;

        public ObservableMeters(HardwareConfig hardwareConfig, ObservableCollection<IMeter> meters = null)
        {
            this.hardwareConfig = hardwareConfig;
            this.meters = meters;
            // Wire up the CollectionChanged event.
            if (meters != null)
            {
                this.meters.CollectionChanged += OnCollectionChanged;
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Implement here logic for adding/removing tables to the collection
            throw new NotImplementedException();
        }

        public ObservableCollection<IMeter> GetMeters()
        {
            return meters;
        }

        public MainboardMeter GetMainboardMeter()
        {
            if (hardwareConfig.MainboardEnabled)
            {
                return meters.Where(x => x.GetHardwareType() == HardwareType.Mainboard).OfType<MainboardMeter>().FirstOrDefault();
            }

            return null;
        }

        public CpuMeter GetCpuMeter()
        {
            if (hardwareConfig.CPUEnabled)
            {
                return meters.Where(x => x.GetHardwareType() == HardwareType.CPU).OfType<CpuMeter>().FirstOrDefault();
            }

            return null;
        }

        public HardwareConfig GetHardwareConfig()
        {
            return hardwareConfig;
        }
    }
}
