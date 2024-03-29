﻿using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NiceMeter.Meters
{
    public abstract class AbstractMeter : INotifyPropertyChanged, IMeter
    {
        public const string UNITS_SEPARATOR = " ";

        public string Name { get; set; }
        public HardwareType HardwareType { get; set; }
        private string text;

        /// <summary>
        /// The public property used to display the value of the meters. Must be the final, well-formatted string (e.g. 22°C)
        /// </summary>
        public string Text
        {
            get { return text; }

            set { text = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected AbstractMeter(string name, HardwareType hardwareType)
        {
            Name = name;
            HardwareType = hardwareType;
        }

        /// <summary>
        /// Event implementation
        /// </summary>
        private void OnPropertyChanged(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public HardwareType GetHardwareType()
        {
            return HardwareType;
        }

        public abstract IMeter ReadSensors(IHardware hardware);

        public abstract void UpdateMeters(IHardware hardware);

        public string FormatUnits(IList<IUnit> units)
        {
             return string.Join(UNITS_SEPARATOR, units.Select(x => x.ToString()));
        }
    }
}
