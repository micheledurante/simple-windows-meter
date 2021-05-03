using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace NiceMeter.Models
{
    /// <summary>
    /// Wrap OpenHardwareMonitor's Computer class to implement our IComputer interface adding missing methods from the base classes
    /// </summary>
    public class ComputerModel : Computer, IComputerModel
    {
        public List<IHardware> HardwareListCache { get; set; } = new List<IHardware>();

        /// <inheritdoc/>
        public IHardware FindHardware(HardwareType hardwareType)
        {
            if (HardwareListCache.Where(x => x.HardwareType == hardwareType).Count() != 0)
            {
                return HardwareListCache.Where(x => x.HardwareType == hardwareType).First();
            }

            return null;
        }

        /// <inheritdoc/>
        public IHardware GetMainboardHardware()
        {
            if (MainboardEnabled)
            {
                return FindHardware(HardwareType.Mainboard);
            }

            return null;
        }

        /// <inheritdoc/>
        public IHardware GetCpuHardware()
        {
            if (CPUEnabled)
            {
                return FindHardware(HardwareType.CPU);
            }

            return null;
        }

        /// <inheritdoc/>
        public IHardware GetGpuHardware()
        {
            if (GPUEnabled)
            {
                if (HardwareListCache.Where(x => x.HardwareType == HardwareType.GpuAti).Count() != 0)
                {
                    return FindHardware(HardwareType.GpuAti);
                }
                else
                {
                    return FindHardware(HardwareType.GpuNvidia);
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public IHardware GetHddHardware()
        {
            if (HDDEnabled)
            {
                return FindHardware(HardwareType.HDD);
            }

            return null;
        }

        /// <inheritdoc/>
        public IHardware GetRamHardware()
        {
            if (RAMEnabled)
            {
                return FindHardware(HardwareType.RAM);
            }

            return null;
        }

        /// <inheritdoc/>
        public new void Open()
        {
            base.Open();
            // Cache to avoid creating multiple new lists for each call to Hardware
            HardwareListCache = new List<IHardware>(Hardware);
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
