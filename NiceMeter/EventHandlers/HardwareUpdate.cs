using NiceMeter.Meter;
using OpenHardwareMonitor.Hardware;

namespace NiceMeter.EventHandlers
{
    public class HardwareUpdate
    {
        public void Update(IComputer computer, IVisitorObservable computerVisitor)
        {
            computer.Hardware[1].Update();

            computerVisitor.UpdateCpu(computer.Hardware[1]);
        }
    }
}
