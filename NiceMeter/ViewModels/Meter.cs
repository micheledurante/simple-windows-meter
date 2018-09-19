using OpenHardwareMonitor.Hardware;

namespace NiceMeter.ViewModels
{
    class Meter
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public HardwareType HardwareType { get; set; }
    }
}
