using NiceMeter.Meters;
using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Mainboard;
using NiceMeter.Models;
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
        public readonly HardwareConfig hardwareConfig;
        public ObservableCollection<IMeter> Meters { get; set; } = new ObservableCollection<IMeter>();

        public HardwareVisitor(HardwareConfig hardwareConfig)
        {
            this.hardwareConfig = hardwareConfig;
        }

        public void VisitComputer(IComputer computer)
        {
            throw new NotImplementedException();
        }

        public void VisitHardware(IHardware hardware)
        {
            switch (hardware.HardwareType)
            {
                case HardwareType.Mainboard:
                    var mainboardMeters = new MainboardMeters(hardware.Name, MainboardConfig.GetCrosshair8Mainboard());
                    mainboardMeters.ReadSensors(hardware);
                    Meters.Add(mainboardMeters);
                    break;

                case HardwareType.CPU:
                    var cpuMeters = new CpuMeters(hardware.Name, CpuConfig.GetRyzen3Cpu());
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
            if (hardware != null && hardwareConfig.MainboardEnabled)
            {
                Meters.Where(x => x.GetHardwareType() == HardwareType.Mainboard).First().UpdateMeters(hardware);
            }
        }

        /// <inheritdoc/>
        public void UpdateCpu(IHardware hardware)
        {
            if (hardware != null && hardwareConfig.CPUEnabled)
            {
                Meters.Where(x => x.GetHardwareType() == HardwareType.CPU).First().UpdateMeters(hardware);
            }
        }

        /// <inheritdoc/>
        public void UpdateGpu(IHardware hardware)
        {
            if (hardware != null && hardwareConfig.GPUEnabled)
            {
                //if (Meters.Where(x => x.GetHardwareType() == HardwareType.GpuAti).Count() != 0)
                //{
                //    Meters.Where(x => x.GetHardwareType() == HardwareType.GpuAti).First().UpdateMeters(hardware);
                //}
                //else
                //{
                //    Meters.Where(x => x.GetHardwareType() == HardwareType.GpuNvidia).First().UpdateMeters(hardware);
                //}
            }
        }

        /// <inheritdoc/>
        public void UpdateHdd(IHardware hardware)
        {
            if (hardware != null && hardwareConfig.HDDEnabled)
            {
                //Meters.Where(x => x.GetHardwareType() == HardwareType.HDD).First().UpdateMeters(hardware);
            }
        }

        /// <inheritdoc/>
        public void UpdateRam(IHardware hardware)
        {
            if (hardware != null && hardwareConfig.RAMEnabled)
            {
                //Meters.Where(x => x.GetHardwareType() == HardwareType.RAM).First().UpdateMeters(hardware);
            }
        }
    }
}
