using NiceMeter.ViewModels;
using NiceMeter.ViewModels.Cpu;
using NiceMeter.ViewModels.Mainboard;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace NiceMeter.Meters
{
    /// <summary>
    /// Update meters with the values read from the visited computer
    /// </summary>
    public class ComputerVisitor : IVisitorObservable
    {
        private ObservableCollection<IMeter> meters = new ObservableCollection<IMeter>();

        public void VisitComputer(IComputer computer)
        {
            throw new NotImplementedException();
        }

        public void VisitHardware(IHardware hardware)
        {
            switch (hardware.HardwareType)
            {
                case HardwareType.Mainboard:
                    meters.Add(new MainboardMeter(hardware.Name).ReadSensors(null));
                    break;

                case HardwareType.CPU:
                    meters.Add(new CpuMeter(hardware.Name).ReadSensors(hardware.Sensors));

                    // Get the core(s)
                    var cores = hardware.Sensors.Where(x => x.SensorType == SensorType.Load && x.Name.Contains("Core")).Select(x => x.Name).ToList();

                    foreach (var core in cores)
                    {
                        meters.Add(new CoreMeter(core).ReadSensors(hardware.Sensors));
                    }

                    break;
            }
        }

        public void VisitParameter(IParameter parameter)
        {
            throw new NotImplementedException();
        }

        public void VisitSensor(ISensor sensor)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void UpdateMainboard(IHardware hardware)
        {
            if (hardware == null)
            {
                return;
            }
        }

        /// <inheritdoc/>
        public void UpdateCpu(IHardware hardware)
        {
            if (hardware == null)
            {
                return;
            }

            var cpuMeters = meters.Where(x => x.GetHardwareType() == HardwareType.CPU).ToList();

            foreach (var cpuMeter in cpuMeters)
            {
                cpuMeter.UpdateMeters(hardware.Sensors);
            }
        }

        public ObservableCollection<IMeter> ConvertMeters()
        {
            foreach (var meter in meters)
            {
                meter.FormatMeters();
            }

            return meters;
        }
    }
}
