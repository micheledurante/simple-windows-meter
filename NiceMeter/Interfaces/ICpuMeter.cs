using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.Interfaces
{
    interface ICpuMeter
    {
        IMeter UpdateValues(IList<ISensor> sensors);
    }
}
