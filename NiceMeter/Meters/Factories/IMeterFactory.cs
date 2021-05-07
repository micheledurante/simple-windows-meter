using OpenHardwareMonitor.Hardware;

namespace NiceMeter.Meters.Factories
{
    public interface IMeterFactory
    {
        IMeter Create(IHardware hardware);
    }
}
