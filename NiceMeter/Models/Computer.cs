using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Models
{
    /// <summary>
    /// Wrap OpenHardwareMonitor's Computer class to implement our IComputer interface adding missing methods from the base classes
    /// </summary>
    public class Computer : OpenHardwareMonitor.Hardware.Computer, IComputer
    {
        public List<OpenHardwareMonitor.Hardware.IHardware> HardwareListCache { get; set; } = new List<OpenHardwareMonitor.Hardware.IHardware>();

        /// <inheritdoc/>
        public OpenHardwareMonitor.Hardware.IHardware FindHardware(OpenHardwareMonitor.Hardware.HardwareType hardwareType)
        {
            if (HardwareListCache.Where(x => x.HardwareType == hardwareType).Count() != 0)
            {
                return HardwareListCache.Where(x => x.HardwareType == hardwareType).First();
            }

            return null;
        }

        /// <inheritdoc/>
        public OpenHardwareMonitor.Hardware.IHardware GetMainboardHardware()
        {
            if (MainboardEnabled)
            {
                return FindHardware(OpenHardwareMonitor.Hardware.HardwareType.Mainboard);
            }

            return null;
        }

        /// <inheritdoc/>
        public OpenHardwareMonitor.Hardware.IHardware GetCpuHardware()
        {
            if (CPUEnabled)
            {
                return FindHardware(OpenHardwareMonitor.Hardware.HardwareType.CPU);
            }

            return null;
        }

        /// <inheritdoc/>
        public OpenHardwareMonitor.Hardware.IHardware GetGpuHardware()
        {
            if (GPUEnabled)
            {
                if (HardwareListCache.Where(x => x.HardwareType == OpenHardwareMonitor.Hardware.HardwareType.GpuAti).Count() != 0)
                {
                    return FindHardware(OpenHardwareMonitor.Hardware.HardwareType.GpuAti);
                }
                else
                {
                    return FindHardware(OpenHardwareMonitor.Hardware.HardwareType.GpuNvidia);
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public OpenHardwareMonitor.Hardware.IHardware GetHddHardware()
        {
            if (HDDEnabled)
            {
                return FindHardware(OpenHardwareMonitor.Hardware.HardwareType.HDD);
            }

            return null;
        }

        /// <inheritdoc/>
        public OpenHardwareMonitor.Hardware.IHardware GetRamHardware()
        {
            if (RAMEnabled)
            {
                return FindHardware(OpenHardwareMonitor.Hardware.HardwareType.RAM);
            }

            return null;
        }

        /// <inheritdoc/>
        public new void Open()
        {
            base.Open();
            // Cache to avoid creating multiple new lists for each call to Hardware
            HardwareListCache = new List<OpenHardwareMonitor.Hardware.IHardware>(Hardware);
        }

        /// <inheritdoc/>
        public new void Reset()
        {
            base.Reset();
        }

        /// <inheritdoc/>
        public new void Close()
        {
            base.Close();
        }
    }
}
