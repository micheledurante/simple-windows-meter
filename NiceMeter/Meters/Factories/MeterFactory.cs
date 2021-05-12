using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Gpu;
using NiceMeter.Meters.Hdd;
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
                case HardwareType.HDD:
                    return new HddMeter();
                case HardwareType.CPU:
                    return new CpuMeter(hardware.Name, new CpuConfig());
                case HardwareType.GpuAti:
                case HardwareType.GpuNvidia:
                    return new GpuMeter(hardware.Name, hardware.HardwareType, new GpuConfig());
                default:
                    throw new Exception(string.Format("Hardware type \"{0}\" not understood", hardware.HardwareType));
            }
        }
    }
}
