using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.ViewModels
{
    class MainboardMeter : Meter, IMeter
    {
        public MainboardMeter(string name)
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
