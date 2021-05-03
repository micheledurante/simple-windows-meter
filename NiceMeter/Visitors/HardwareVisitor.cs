using NiceMeter.Meters;
using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Mainboard;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace NiceMeter.Visitors
{
    /// <summary>
    /// Update meters with the values from the visited computer's hardware (sensors)
    /// </summary>
    public class HardwareVisitor : IHardwareVisitor
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
                    meters.Add(new MainboardMeters(hardware.Name).ReadSensors(hardware));
                    break;

                case HardwareType.CPU:
                    meters.Add(new CpuMeter(hardware.Name).ReadSensors(hardware));

                    // Get the core(s)
                    var cores = hardware.Sensors.Where(x => x.SensorType == SensorType.Load && x.Name.Contains("Core")).Select(x => x.Name).ToList();

                    foreach (var core in cores)
                    {
                        meters.Add(new CoreMeter(core).ReadSensors(hardware));
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

            meters.Where(x => x.GetHardwareType() == HardwareType.Mainboard).First().UpdateMeters(hardware);
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
                cpuMeter.UpdateMeters(hardware);
            }
        }

        /// <inheritdoc/>
        public void UpdateGpu(IHardware hardware)
        {
            if (hardware == null)
            {
                return;
            }
        }

        /// <inheritdoc/>
        public void UpdateHdd(IHardware hardware)
        {
            if (hardware == null)
            {
                return;
            }
        }

        /// <inheritdoc/>
        public void UpdateRam(IHardware hardware)
        {
            if (hardware == null)
            {
                return;
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
