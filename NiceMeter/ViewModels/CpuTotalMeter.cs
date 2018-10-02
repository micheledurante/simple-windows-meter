using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.ViewModels
{
    class CpuTotalMeter : CpuMeter, ICpuMeter
    {
        public IMeter UpdateValues(IList<ISensor> sensors)
        {
            throw new NotImplementedException();
        }
    }
}
