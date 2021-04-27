using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace NiceMeter.Meter
{
    public interface IMeter
    {
        IMeter FilterSensors(IList<ISensor> sensors);

        IMeter GetDisplayMeter();

        HardwareType GetHardwareType();

        void UpdateMeter(IList<ISensor> sensors);
    }
}
