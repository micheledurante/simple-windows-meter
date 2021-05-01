using OpenHardwareMonitor.Hardware;
using System.Collections.ObjectModel;

namespace NiceMeter.ViewModels
{
    public interface IVisitorObservable : IVisitor
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
    }
}
