using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Hdd;
using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;

namespace NiceMeterTests.Meters.Hdd
{
    [TestClass]
    public class HddMeterTest
    {
        [TestMethod]
        public void Ctor_ProvidedBaseCtorParameters_ShoulSetBaseCtorParameters()
        {
            var hddMeter = new HddMeter();

            Assert.AreEqual(HddMeter.DefaultMeterName, hddMeter.Name);
            Assert.AreEqual(HardwareType.HDD, hddMeter.HardwareType);
        }

        [TestMethod]
        public void Ctor_NoConfgiRequired_AllMetersShouldBeAddedToUnits()
        {
            var hddMeter = new HddMeter();

            Assert.AreEqual(1, hddMeter.Units.Count);
            Assert.IsInstanceOfType(hddMeter.Units[0], typeof(PercentUnit));
        }
    }
}
