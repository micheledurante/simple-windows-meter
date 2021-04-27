using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace NiceMeter.Interfaces
{
    public interface IMeter
    {
        IMeter FilterSensors(IList<ISensor> sensors);

        IMeter GetDisplayMeter();

        HardwareType GetHardwareType();

        void UpdateMeter(IList<ISensor> sensors);
    }
}
