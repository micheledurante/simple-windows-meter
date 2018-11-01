using log4net;
using NiceMeter.Interfaces;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.ViewModels
{
    class CpuMeter : Meter, IMeter
    {
        private IList<ICpuCore> meters = new List<ICpuCore>();
        private IList<string> cores = new List<string>();
        private Unit power = null;
        private static readonly ILog log = LogManager.GetLogger(typeof(CpuMeter));

        public CpuMeter(string name)
        {
            Name = name;
        }

        public IMeter FormatSensors(IList<ISensor> sensors)
        {
            // Filter CPU names
            cores = sensors.Where(x => x.SensorType == SensorType.Load && x.Name.Contains("Core")).Select(x => x.Name).ToList();

            foreach (var core in cores)
            {
                meters.Add(new CpuCore(core)
                { 
                    Load = new Unit(string.Format("{0}", sensors.Where(x => x.Name == core && x.SensorType == SensorType.Load).First().Value), "%"),

                    Freq = new Unit(string.Format("{0:N2}", sensors.Where(x => x.Name == core && x.SensorType == SensorType.Clock).First().Value / 1000), "GHz"),

                    Temp = new Unit(string.Format("{0:N0}", sensors.Where(x => x.Name == core && x.SensorType == SensorType.Temperature).First().Value), "°C")
                });
            }

            power = new Unit(string.Format("{0:N0}", sensors.Where(x => x.SensorType == SensorType.Power && x.Name.Contains("CPU Package")).First().Value), "W");

            return this;
        }

        public IMeter GetDisplayValue()
        {
            Text = power.ToString();

            foreach (var meter in meters)
            {
                meter.GetDisplayValue();
            }

            return this;
        }
    }
}
