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
        private static readonly ILog log = LogManager.GetLogger(typeof(CpuMeter));

        public CpuMeter(string name)
        {
            Name = name;
        }

        public IMeter FormatValues(IList<ISensor> sensors)
        {
            // Select CPU cores only
            var cpuSensors = sensors.Where(x => x.SensorType == SensorType.Load && x.Name.Contains("Core")).ToList();

            foreach (var cpuSensor in cpuSensors)
            {
                coreMeters.Add(new CpuCoreMeter(cpuSensor.Name) {

                    load = new Unit(string.Format("{0:N2}", cpuSensor.Value), "%"),

                    freq = new Unit(string.Format("{0}{1:N2}", "@", cpuSensor.Value), "MHz"),

                    temp = new Unit(string.Format("{0:N2}", cpuSensor.Value), "°C")
                });
            }

            return this;
        }
    }
}
