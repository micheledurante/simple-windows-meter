using OpenHardwareMonitor.Hardware;
using System.ComponentModel;

namespace NiceMeter.ViewModels
{
    internal abstract class AbstractMeter : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public HardwareType HardwareType { get; set; }
        private string text;
        public string Text
        {
            get { return text; }

            set { text = value; OnPropertyChanged(); }
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
