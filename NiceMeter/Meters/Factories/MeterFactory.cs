using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Mainboard;
using NiceMeter.Meters.Ram;
using OpenHardwareMonitor.Hardware;
using System;

namespace NiceMeter.Meters.Factories
{
    public class MeterFactory : IMeterFactory
    {
        public IMeter Create(IHardware hardware)
        {
            switch (hardware.HardwareType)
            {
                case HardwareType.Mainboard:
                    return new MainboardMeter(hardware.Name, new MainboardConfig());
                case HardwareType.RAM:
                    return new RamMeter();
                case HardwareType.CPU:
                    return new CpuMeter(hardware.Name, new CpuConfig());
                default:
                    throw new Exception(string.Format("Hardware type \"{0}\" not understood", hardware.HardwareType));
            }
        }
    }
}
