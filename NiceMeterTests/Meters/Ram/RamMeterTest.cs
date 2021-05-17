using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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

            Assert.AreEqual(RamMeter.DEFAULT_METER_NAME, ramMeter.Name);
            Assert.AreEqual(HardwareType.RAM, ramMeter.HardwareType);
        }

        [TestMethod]
        public void Ctor_NoConfigRequired_UnitOHNamesAreSetFromConsts()
        {
            var ramMeter = new RamMeter();

            Assert.AreEqual(ramMeter.AvailableMemory.OHName, RamMeter.AVAILABLE_MEMORY_OHNAME);
            Assert.AreEqual(ramMeter.UsedMemory.OHName, RamMeter.USED_MEMORY_OHNAME);
            Assert.AreEqual(ramMeter.Memory.OHName, RamMeter.MEMORY_OHNAME);
        }

        [TestMethod]
        public void Ctor_NoConfigRequired_AllMetersShouldBeAddedToUnits()
        {
            var ramMeter = new RamMeter();

            Assert.AreEqual(3, ramMeter.Units.Count);
            Assert.IsInstanceOfType(ramMeter.AvailableMemory, typeof(RamGbUnit));
            Assert.IsInstanceOfType(ramMeter.UsedMemory, typeof(RamGbUnit));     
            Assert.IsInstanceOfType(ramMeter.Memory, typeof(RamPercentUnit));
        }

        [TestMethod]
        public void ReadSensors_UnitsAreAlwaysPresent_ShouldSetValuesForAllRamUnits()
        {
            var availableMemoryValue = new Faker().Random.Number();
            var usedMemoryValue = new Faker().Random.Number();
            var memoryValue = new Faker().Random.Number();          
            var availableMemorySensorMock = new Mock<ISensor>();
            availableMemorySensorMock.SetupGet(x => x.Name).Returns(RamMeter.AVAILABLE_MEMORY_OHNAME);
            availableMemorySensorMock.SetupGet(x => x.Value).Returns(availableMemoryValue);
            var usedMemorySensorMock = new Mock<ISensor>();
            usedMemorySensorMock.SetupGet(x => x.Name).Returns(RamMeter.USED_MEMORY_OHNAME);
            usedMemorySensorMock.SetupGet(x => x.Value).Returns(usedMemoryValue);
            var memorySensorMock = new Mock<ISensor>();
            memorySensorMock.SetupGet(x => x.Name).Returns(RamMeter.MEMORY_OHNAME);
            memorySensorMock.SetupGet(x => x.Value).Returns(memoryValue);
            var sensors = new ISensor[3];
            sensors[0] = availableMemorySensorMock.Object;
            sensors[1] = usedMemorySensorMock.Object;
            sensors[2] = memorySensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var ramMeter = new RamMeter();
            ramMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Exactly(3));
            availableMemorySensorMock.VerifyGet(x => x.Value, Times.Once);
            usedMemorySensorMock.VerifyGet(x => x.Value, Times.Once);
            memorySensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(availableMemoryValue, ramMeter.AvailableMemory.Value);
            Assert.AreEqual(usedMemoryValue, ramMeter.UsedMemory.Value);
            Assert.AreEqual(memoryValue, ramMeter.Memory.Value);
        }
    }
}
