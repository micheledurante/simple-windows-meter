using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Ram;
using OpenHardwareMonitor.Hardware;

namespace NiceMeterTests.Meters.Ram
{
    [TestClass]
    public class RamMeterTest
    {
        [TestMethod]
        public void Ctor_ProvidedBaseCtorParameters_ShoulSetBaseCtorParameters()
        {
            var ramMeter = new RamMeter();

            Assert.AreEqual(RamMeter.DefaultMeterName, ramMeter.Name);
            Assert.AreEqual(HardwareType.RAM, ramMeter.HardwareType);
        }

        [TestMethod]
        public void Ctor_NoConfgiRequired_AllMetersShouldBeAddedToUnits()
        {
            var ramMeter = new RamMeter();

            Assert.AreEqual(3, ramMeter.Units.Count);
            Assert.IsInstanceOfType(ramMeter.Units[0], typeof(RamGbUnit));
            Assert.IsInstanceOfType(ramMeter.Units[1], typeof(RamGbUnit));
            Assert.IsInstanceOfType(ramMeter.Units[2], typeof(RamPercentUnit));
        }
    }
}
