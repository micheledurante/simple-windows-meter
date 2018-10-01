using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.ViewModels
{
    class CpuCoreMeter : Meter, IMeter
    {
        public CpuCoreMeter(IList<ISensor> sensors)
        {
            
        }

        public IMeter FormatText(IList<ISensor> cores)
        {
            
        }

        public IMeter UpdateText(IList<ISensor> sensors)
        {
            throw new NotImplementedException();
        }
    }
}
