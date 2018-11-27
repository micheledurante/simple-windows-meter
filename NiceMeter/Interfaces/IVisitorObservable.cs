using OpenHardwareMonitor.Hardware;
using System.Collections.ObjectModel;

namespace NiceMeter.Interfaces
{
    public interface IVisitorObservable
    {
        ObservableCollection<IMeter> GetDisplayMeters();

        void UpdateCpu(IHardware hardware);        
    }
}
