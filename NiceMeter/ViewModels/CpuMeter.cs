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
            // Create CPUs list
            var cores = sensors.Where(x => x.SensorType == SensorType.Load && x.Name.Contains("Core")).Select(x => new { x.Name }).ToList();

            foreach (var core in cores)
            {
                coreMeters.Add(new CpuCoreMeter(core.Name) {

                    load = new Unit(string.Format(
                        "{0:N2}",
                        sensors.Where(
                                x => x.Name == core.Name && x.SensorType == SensorType.Load
                            ).Select(
                                x => new { x.Value }
                            ).ToString()
                            ), "%"
                        ),

                    freq = new Unit(string.Format("{0}{1:N2}", "@", sensors.Where(x => x.Name == core.Name && x.SensorType == SensorType.Clock).Select(x => new { x.Value }).ToString()), "MHz"),

                    temp = new Unit(string.Format("{0:N2}", sensors.Where(x => x.Name == core.Name && x.SensorType == SensorType.Temperature).Select(x => new { x.Value }).ToString()), "°C")
                });
            }

            return this;
        }
    }
}
