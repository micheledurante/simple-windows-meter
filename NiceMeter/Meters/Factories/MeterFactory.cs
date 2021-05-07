using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Mainboard;
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
                    return new MainboardMeter(hardware.Name, MainboardConfig.GetCrosshair8Mainboard());
                case HardwareType.CPU:
                    return new CpuMeter(hardware.Name, CpuConfig.GetRyzen3Cpu());
                default:
                    throw new Exception(string.Format("Hardware type \"{0}\" not understood", hardware.HardwareType));
            }
        }
    }
}
