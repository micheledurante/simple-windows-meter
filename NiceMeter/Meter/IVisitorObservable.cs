using OpenHardwareMonitor.Hardware;
using System.Collections.ObjectModel;

namespace NiceMeter.Meter
{
    public interface IVisitorObservable : IVisitor
    {
        ObservableCollection<IMeter> GetDisplayMeters();

        void UpdateCpu(IHardware hardware);
    }
}
