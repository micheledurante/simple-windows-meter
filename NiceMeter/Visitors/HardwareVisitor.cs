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
        private ObservableCollection<IMeter> Meters { get; set; } = new ObservableCollection<IMeter>();

        public void VisitComputer(IComputer computer)
        {
            throw new NotImplementedException();
        }

        public void VisitHardware(IHardware hardware)
        {
            switch (hardware.HardwareType)
            {
                case HardwareType.Mainboard:
                    var mainboardMeters = new MainboardMeters(hardware.Name, MainboardConfig.GetTestingMainboard());
                    mainboardMeters.ReadSensors(hardware);
                    Meters.Add(mainboardMeters);
                    break;

                case HardwareType.CPU:
                    var cpuMeters = new CpuMeters(hardware.Name, CpuConfig.GetTestingCpu());
                    cpuMeters.ReadSensors(hardware);
                    Meters.Add(cpuMeters);
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
        public ObservableCollection<IMeter> GetMeters()
        {
            return Meters;
        }

        /// <inheritdoc/>
        public void UpdateMainboard(IHardware hardware)
        {
            if (hardware == null)
            {
                return;
            }

            Meters.Where(x => x.GetHardwareType() == HardwareType.Mainboard).First().UpdateMeters(hardware);
        }

        /// <inheritdoc/>
        public void UpdateCpu(IHardware hardware)
        {
            if (hardware == null)
            {
                return;
            }

            var cpuMeters = Meters.Where(x => x.GetHardwareType() == HardwareType.CPU).ToList();

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
    }
}
