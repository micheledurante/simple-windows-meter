using OpenHardwareMonitor.Hardware;
using System.Collections.ObjectModel;

namespace NiceMeter.ViewModels
{
    public interface IVisitorObservable : IVisitor
    {
        ObservableCollection<IMeter> GetDisplayMeters();

        void UpdateCpu(IHardware hardware);
    }
}
