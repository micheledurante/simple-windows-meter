﻿using NiceMeter.Interfaces;
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
        public CpuCoreMeter()
        {
            
        }

        public new IMeter FormatText(IList<ISensor> cores)
        {
            return this;
        }

        public new IMeter FormatValues(IList<ISensor> sensors)
        {
            throw new NotImplementedException();
        }

        public IMeter UpdateValues(IList<ISensor> sensors)
        {
            throw new NotImplementedException();
        }
    }
}
