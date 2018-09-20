using OpenHardwareMonitor.Hardware;
using System.ComponentModel;

namespace NiceMeter.ViewModels
{
    class Meter : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public HardwareType HardwareType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
