using NiceMeter.Interfaces;
using NiceMeter.Structs;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.ViewModels
{
    class CpuCoreMeter : CpuMeter, ICpuMeter
    {
        public Unit load { get; set; }
        public Unit temp { get; set; }
        public Unit freq { get; set; }

        public CpuCoreMeter(string name) : base(name)
        {
            Name = name;
        }

        public IMeter FormatValues(float sensor)
        {
            throw new NotImplementedException();
        }

        public IMeter UpdateValue(float sensor)
        {
            throw new NotImplementedException();
        }
    }
}
