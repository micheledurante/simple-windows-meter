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
        private List<ICpuMeter> coreMeters = new List<ICpuMeter>();

        public IMeter FormatText(IHardware hardware)
        {
            Name = hardware.Name;
            return this;
        }

        public IMeter FormatValues(IList<ISensor> sensors)
        {
            return this;
        }
    }
}
