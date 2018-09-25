using OpenHardwareMonitor.Hardware;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NiceMeter.ViewModels
{
    class Meter : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private string _text;
        public string Text
        {
            get { return _text; }

            set { _text = value; OnPropertyChanged(); }
        }

        public HardwareType HardwareType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event implementation
        /// </summary>
       protected void OnPropertyChanged(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
