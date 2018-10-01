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
        private List<CpuCoreMeter> coreMeters = new List<CpuCoreMeter>();

        public CpuMeter(string name, int cores)
        {
            Name = name;
            HardwareType = HardwareType.CPU;
        }

        public IMeter FormatText(IList<ISensor> sensors)
        {
            var cores = sensors.GroupBy(x => x.Identifier).ToList();

            foreach (var core in cores)
            {
                coreMeters.Add(new CpuCoreMeter(core.Select(x => x).ToList()));
            }
        }

        public IMeter UpdateText(IList<ISensor> sensors)
        {
            throw new NotImplementedException();
        }
    }
}
