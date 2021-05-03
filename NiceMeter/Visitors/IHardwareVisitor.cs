using NiceMeter.Meters;
using OpenHardwareMonitor.Hardware;
using System.Collections.ObjectModel;

namespace NiceMeter.Visitors
{
    public interface IHardwareVisitor : IVisitor
    {
        /// <summary>
        /// Convert the internal meters for displaying in the UI
        /// </summary>
        /// <returns></returns>
        ObservableCollection<IMeter> ConvertMeters();

        /// <summary>
        /// Update Mainboard meters based on the given hardware's sensor values
        /// </summary>
        /// <param name="hardware"></param>
        void UpdateMainboard(IHardware hardware);

        /// <summary>
        /// Update CPU meters based on the given hardware's sensor values
        /// </summary>
        /// <param name="hardware"></param>
        void UpdateCpu(IHardware hardware);

        /// <summary>
        /// Update GPU meters based on the given hardware's sensor values
        /// </summary>
        /// <param name="hardware"></param>
        void UpdateGpu(IHardware hardware);

        /// <summary>
        /// Update HDD meters based on the given hardware's sensor values
        /// </summary>
        /// <param name="hardware"></param>
        void UpdateHdd(IHardware hardware);

        /// <summary>
        /// Update RAM meters based on the given hardware's sensor values
        /// </summary>
        /// <param name="hardware"></param>
        void UpdateRam(IHardware hardware);
    }
}
