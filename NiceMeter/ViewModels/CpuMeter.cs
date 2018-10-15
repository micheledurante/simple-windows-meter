using log4net;
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
        private IList<ICpuMeter> coreMeters = new List<ICpuMeter>();
        private ICpuMeter total = null;
        private int cores = 0;
        private static readonly ILog log = LogManager.GetLogger(typeof(CpuMeter));

        public CpuMeter(string name)
        {
            Name = name;
        }

        public IMeter FormatValue(IList<ISensor> sensors)
        {
            foreach (var sensor in sensors)
            {
                log.Debug(string.Format("{0} {1} {2} {3}", sensor.Identifier, sensor.Name, sensor.Value, sensor.SensorType));
            }

            foreach (var sensor in sensors)
            {
                switch (sensor.SensorType)
                {
                    case SensorType.Load:
                        var cpuCoreMeter = new CpuCoreMeter(sensor.Name);
                        cpuCoreMeter.load(sensor.Value, '%');
                        coreMeters.Add();
                }
            }

            return this;  
        }
    }
}
