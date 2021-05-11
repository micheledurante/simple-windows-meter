using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Meters;
using NiceMeter.Meters.Factories;
using NiceMeter.Models;
using NiceMeter.Visitors;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.ObjectModel;

namespace NiceMeterTests.Visitors
{
    [TestClass]
    public class HardwareVisitorTest
    {
        [TestMethod]
        public void Ctor_ValidParameter_ShouldSetExpectedProperty()
        {
            var configMock = new Mock<HardwareConfig>();
            var hardwareVisitor = new HardwareVisitor(configMock.Object, new Mock<IMeterFactory>().Object);

            Assert.AreEqual(configMock.Object, hardwareVisitor.hardwareConfig);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void VisitComputer_NotImplemented_ShouldThrowNotImplementedException()
        {
            var configMock = new Mock<HardwareConfig>();
            var computerMock = new Mock<IComputer>();
            var hardwareVisitor = new HardwareVisitor(configMock.Object, new Mock<IMeterFactory>().Object);

            hardwareVisitor.VisitComputer(computerMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void VisitParameter_NotImplemented_ShouldThrowNotImplementedException()
        {
            var configMock = new Mock<HardwareConfig>();
            var parameterMock = new Mock<IParameter>();
            var hardwareVisitor = new HardwareVisitor(configMock.Object, new Mock<IMeterFactory>().Object);

            hardwareVisitor.VisitParameter(parameterMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void VisitSensor_NotImplemented_ShouldThrowNotImplementedException()
        {
            var configMock = new Mock<HardwareConfig>();
            var sensorMock = new Mock<ISensor>();
            var hardwareVisitor = new HardwareVisitor(configMock.Object, new Mock<IMeterFactory>().Object);

            hardwareVisitor.VisitSensor(sensorMock.Object);
        }

        [TestMethod]
        public void GetMeters_Default_ShouldReturnTheMetersList()
        {
            var configMock = new Mock<HardwareConfig>();
            var hardwareVisitor = new HardwareVisitor(configMock.Object, new Mock<IMeterFactory>().Object);

            Assert.IsInstanceOfType(hardwareVisitor.GetMeters(), typeof(ObservableCollection<IMeter>));
        }

        [TestMethod]
        public void VisitHardware_Default_ShouldCallTheFactoryWithTheGivenHardware()
        {
            var configMock = new Mock<HardwareConfig>();
            var meterFactoryMock = new Mock<IMeterFactory>();
            var hardwareMock = new Mock<IHardware>();
            var meterMock = new Mock<IMeter>();
            meterFactoryMock.Setup(x => x.Create(hardwareMock.Object)).Returns(meterMock.Object);
            meterMock.Setup(x => x.ReadSensors(hardwareMock.Object)).Returns(meterMock.Object);

            var hardwareVisitor = new HardwareVisitor(configMock.Object, meterFactoryMock.Object);
            hardwareVisitor.VisitHardware(hardwareMock.Object);

            meterFactoryMock.Verify(x => x.Create(hardwareMock.Object), Times.Once);
            meterMock.Verify(x => x.ReadSensors(hardwareMock.Object), Times.Once);
            Assert.AreEqual(hardwareVisitor.Meters[0], meterMock.Object);
        }

        // Update Mainboard

        [TestMethod]
        public void UpdateMainboard_MotherboardDisabled_ShouldNotUpdateTheMainboard()
        {
            var hardwareConfig = new HardwareConfig { MainboardEnabled = false};
            var hardwareMock = new Mock<IHardware>();
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.UpdateMeters(hardwareMock.Object));
            var hardwareVisitor = new HardwareVisitor(hardwareConfig, new Mock<IMeterFactory>().Object);

            hardwareVisitor.Meters.Add(meterMock.Object);
            hardwareVisitor.UpdateMainboard(hardwareMock.Object);

            meterMock.Verify(x => x.UpdateMeters(hardwareMock.Object), Times.Never);
        }

        [TestMethod]
        public void UpdateMainboard_MotherboardEnabled_ShouldUpdateTheMainboard()
        {
            var hardwareConfig = new HardwareConfig { MainboardEnabled = true};
            var hardwareMock = new Mock<IHardware>();
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.UpdateMeters(hardwareMock.Object));
            var hardwareVisitor = new HardwareVisitor(hardwareConfig, new Mock<IMeterFactory>().Object);

            hardwareVisitor.Meters.Add(meterMock.Object);
            hardwareVisitor.UpdateMainboard(hardwareMock.Object);

            meterMock.Verify(x => x.UpdateMeters(hardwareMock.Object), Times.Once);
            meterMock.Verify(x => x.GetHardwareType(), Times.Once);
        }

        // Update CPU

        [TestMethod]
        public void UpdateCpu_CpuDisabled_ShouldNotUpdateTheMainboard()
        {
            var hardwareConfig = new HardwareConfig { CPUEnabled = false };
            var hardwareMock = new Mock<IHardware>();
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.UpdateMeters(hardwareMock.Object));
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.Mainboard);
            var hardwareVisitor = new HardwareVisitor(hardwareConfig, new Mock<IMeterFactory>().Object);

            hardwareVisitor.Meters.Add(meterMock.Object);
            hardwareVisitor.UpdateCpu(hardwareMock.Object);

            meterMock.Verify(x => x.UpdateMeters(hardwareMock.Object), Times.Never);
        }

        [TestMethod]
        public void UpdateCpu_CpuEnabled_ShouldUpdateTheMainboard()
        {
            var hardwareConfig = new HardwareConfig { CPUEnabled = true };
            var hardwareMock = new Mock<IHardware>();
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.UpdateMeters(hardwareMock.Object));
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.CPU);
            var hardwareVisitor = new HardwareVisitor(hardwareConfig, new Mock<IMeterFactory>().Object);

            hardwareVisitor.Meters.Add(meterMock.Object);
            hardwareVisitor.UpdateCpu(hardwareMock.Object);

            meterMock.Verify(x => x.UpdateMeters(hardwareMock.Object), Times.Once);
            meterMock.Verify(x => x.GetHardwareType(), Times.Once);
        }

        // Update RAM

        [TestMethod]
        public void UpdateRam_RamDisabled_ShouldNotUpdateTheRam()
        {
            var hardwareConfig = new HardwareConfig { RAMEnabled = false };
            var hardwareMock = new Mock<IHardware>();
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.UpdateMeters(hardwareMock.Object));
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.RAM);
            var hardwareVisitor = new HardwareVisitor(hardwareConfig, new Mock<IMeterFactory>().Object);

            hardwareVisitor.Meters.Add(meterMock.Object);
            hardwareVisitor.UpdateRam(hardwareMock.Object);

            meterMock.Verify(x => x.UpdateMeters(hardwareMock.Object), Times.Never);
        }

        [TestMethod]
        public void UpdateRam_RamEnabled_ShouldUpdateTheRam()
        {
            var hardwareConfig = new HardwareConfig { RAMEnabled = true };
            var hardwareMock = new Mock<IHardware>();
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.UpdateMeters(hardwareMock.Object));
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.RAM);
            var hardwareVisitor = new HardwareVisitor(hardwareConfig, new Mock<IMeterFactory>().Object);

            hardwareVisitor.Meters.Add(meterMock.Object);
            hardwareVisitor.UpdateRam(hardwareMock.Object);

            meterMock.Verify(x => x.UpdateMeters(hardwareMock.Object), Times.Once);
            meterMock.Verify(x => x.GetHardwareType(), Times.Once);
        }

        // Update HDD

        [TestMethod]
        public void UpdateHdd_HddDisabled_ShouldNotUpdateTheHdd()
        {
            var hardwareConfig = new HardwareConfig { HDDEnabled = false };
            var hardwareMock = new Mock<IHardware>();
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.UpdateMeters(hardwareMock.Object));
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.HDD);
            var hardwareVisitor = new HardwareVisitor(hardwareConfig, new Mock<IMeterFactory>().Object);

            hardwareVisitor.Meters.Add(meterMock.Object);
            hardwareVisitor.UpdateHdd(hardwareMock.Object);

            meterMock.Verify(x => x.UpdateMeters(hardwareMock.Object), Times.Never);
        }

        [TestMethod]
        public void UpdateHdd_HddEnabled_ShouldUpdateTheHdd()
        {
            var hardwareConfig = new HardwareConfig { HDDEnabled = true };
            var hardwareMock = new Mock<IHardware>();
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.UpdateMeters(hardwareMock.Object));
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.HDD);
            var hardwareVisitor = new HardwareVisitor(hardwareConfig, new Mock<IMeterFactory>().Object);

            hardwareVisitor.Meters.Add(meterMock.Object);
            hardwareVisitor.UpdateHdd(hardwareMock.Object);

            meterMock.Verify(x => x.UpdateMeters(hardwareMock.Object), Times.Once);
            meterMock.Verify(x => x.GetHardwareType(), Times.Once);
        }
    }
}
