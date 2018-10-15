using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.ComponentModel;

namespace NiceMeter.ViewModels
{
    internal abstract class Meter : INotifyPropertyChanged
    {
        protected IList<ISensor> Sensors { get; set; }

        public string Name { get; set; }

        private string _text;

        public string Text
        {
            get { return _text; }

            set { _text = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event implementation
        /// </summary>
        private void OnPropertyChanged(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
