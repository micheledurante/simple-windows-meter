using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Factories;
using NiceMeter.Meters.Hdd;
using NiceMeter.Meters.Mainboard;
using NiceMeter.Meters.Ram;
using OpenHardwareMonitor.Hardware;
using System;

namespace NiceMeterTests.Meters.Factories
{
    [TestClass]
    public class MeterFactoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Create_HardwareTypeNotFound_ShouldThrowException()
        {
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.Setup(x => x.HardwareType).Returns((HardwareType)999);
            var meterFactory = new MeterFactory();

            var meter = meterFactory.Create(hardwareMock.Object);
            hardwareMock.Verify(x => x.HardwareType, Times.Once);
            Assert.IsNull(meter);
        }

        [TestMethod]
        public void Create_MainboardHardwareType_ShouldCreateTheMainboardMeter()
        {
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.Mainboard);
            var meterFactory = new MeterFactory();

            var meter = meterFactory.Create(hardwareMock.Object);
            hardwareMock.Verify(x => x.HardwareType, Times.Once);
            hardwareMock.VerifyGet(x => x.Name, Times.Once);
            Assert.IsInstanceOfType(meter, typeof(MainboardMeter));
        }

        [TestMethod]
        public void Create_CpuHardwareType_ShouldCreateTheCpuMeter()
        {
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.CPU);
            var meterFactory = new MeterFactory();

            var meter = meterFactory.Create(hardwareMock.Object);
            hardwareMock.Verify(x => x.HardwareType, Times.Once);
            hardwareMock.VerifyGet(x => x.Name, Times.Once);
            Assert.IsInstanceOfType(meter, typeof(CpuMeter));
        }

        [TestMethod]
        public void Create_RamHardwareType_ShouldCreateTheRamMeter()
        {
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.RAM);
            var meterFactory = new MeterFactory();

            var meter = meterFactory.Create(hardwareMock.Object);
            hardwareMock.Verify(x => x.HardwareType, Times.Once);
            Assert.IsInstanceOfType(meter, typeof(RamMeter));
        }

        [TestMethod]
        public void Create_HddHardwareType_ShouldCreateTheHddMeter()
        {
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.HDD);
            var meterFactory = new MeterFactory();

            var meter = meterFactory.Create(hardwareMock.Object);
            hardwareMock.Verify(x => x.HardwareType, Times.Once);
            Assert.IsInstanceOfType(meter, typeof(HddMeter));
        }
    }
}
