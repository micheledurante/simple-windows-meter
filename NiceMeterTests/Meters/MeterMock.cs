using NiceMeter.Meters;
using OpenHardwareMonitor.Hardware;

namespace NiceMeterTests.Meters
{
    public class MeterMock : AbstractMeter
    {
        public MeterMock() : base("asd", HardwareType.RAM)
        {

        }

        public override IMeter ReadSensors(IHardware hardware)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateMeters(IHardware hardware)
        {
            throw new System.NotImplementedException();
        }
    }
}
