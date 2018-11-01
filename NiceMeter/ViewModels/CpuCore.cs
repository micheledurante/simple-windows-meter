using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.ViewModels
{
    class CpuCore: CpuMeter, ICpuCore
    {
        public Unit Load { get; set; }

        public Unit Temp { get; set; }

        public Unit Freq { get; set; }

        public CpuCore(string name): base(name)
        {
            Name = name;
        }

        public new IMeter GetDisplayValue()
        {
            Text = string.Format("{0}, {1}, {2}", Load.ToString(), Temp.ToString(), Freq.ToString());
            return this;
        }
    }
}
