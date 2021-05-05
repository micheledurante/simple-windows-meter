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

        /// <summary>
        /// Re-implement the open flag as it is private in the base class
        /// </summary>
        public bool IsOpen { get; set; } = false;

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
        public IHardware FindSubHardware(HardwareType hardwareType)
        {
            if (HardwareListCache
                .Where(x => x.HardwareType == hardwareType && x.SubHardware.Count() != 0)
                .Count() != 0)
            {
                if (HardwareListCache
                    .Where(x => x.HardwareType == hardwareType)
                    .First().SubHardware
                    .Where(s => s.HardwareType == HardwareType.SuperIO).Count() != 0)
                {
                    return HardwareListCache
                        .Where(x => x.HardwareType == hardwareType)
                        .First().SubHardware
                        .Where(s => s.HardwareType == HardwareType.SuperIO)
                        .First();
                }
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
        public IHardware GetMainboardSubHardware()
        {
            if (MainboardEnabled)
            {
                return FindSubHardware(HardwareType.Mainboard);
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
            IsOpen = true;
            base.Open();
            // Cache to avoid creating multiple new lists for each call to Hardware
            if (HardwareListCache.Count == 0)
            {
                HardwareListCache = new List<IHardware>(Hardware);
            }
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

        /// <inheritdoc/>
        public void Update()
        {
            if (IsOpen == false)
            {
                Open();
            }

            GetMainboardHardware()?.Update();
            GetMainboardSubHardware()?.Update();
            GetCpuHardware()?.Update();
            GetGpuHardware()?.Update();
            GetHddHardware()?.Update();
            GetRamHardware()?.Update();
        }
    }
}
