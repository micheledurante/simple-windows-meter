using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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

            Assert.AreEqual(HddMeter.DEFAULT_METER_NAME, hddMeter.Name);
            Assert.AreEqual(HardwareType.HDD, hddMeter.HardwareType);
        }

        [TestMethod]
        public void Ctor_NoConfigRequired_UnitOHNameIsSetFromConst()
        {
            var hddMeter = new HddMeter();

            Assert.AreEqual(hddMeter.UsedSpace.OHName, HddMeter.USED_SPACE_OHNAME);
        }

        [TestMethod]
        public void Ctor_NoConfigRequired_AllMetersShouldBeAddedToUnits()
        {
            var hddMeter = new HddMeter();

            Assert.AreEqual(1, hddMeter.Units.Count);
            Assert.IsInstanceOfType(hddMeter.UsedSpace, typeof(PercentUnit));
        }

        [TestMethod]
        public void ReadSensors_UsedSpaceUnitIsAlwaysPresent_ShouldSetValueForUsedSpaceUnit()
        {
            var usedSpaceValue = new Faker().Random.Number();
            var usedSpaceSensorMock = new Mock<ISensor>();
            usedSpaceSensorMock.SetupGet(x => x.Name).Returns(HddMeter.USED_SPACE_OHNAME);
            usedSpaceSensorMock.SetupGet(x => x.Value).Returns(usedSpaceValue);
            var sensors = new ISensor[1];
            sensors[0] = usedSpaceSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var hddMeter = new HddMeter();
            hddMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            usedSpaceSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(usedSpaceValue, hddMeter.UsedSpace.Value);
        }
    }
}
