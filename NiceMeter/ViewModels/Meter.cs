using OpenHardwareMonitor.Hardware;
using System.ComponentModel;

namespace NiceMeter.ViewModels
{
    public class Meter : INotifyPropertyChanged
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
        private void OnPropertyChanged(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
