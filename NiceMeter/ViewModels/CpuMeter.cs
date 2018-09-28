using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.ViewModels
{
    class CpuMeter : Meter, IMeter
    {
        public CpuMeter(string name, int cores)
        {
            Name = name;
            HardwareType = HardwareType.CPU;
        }

        public IMeter FormatText(IList<ISensor> sensors)
        {
            return this;
        }
    }
}
