using OpenHardwareMonitor.Hardware;
using System.ComponentModel;

namespace NiceMeter.ViewModels
{
    internal abstract class AbstractMeter : INotifyPropertyChanged
    {
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
    }
}
