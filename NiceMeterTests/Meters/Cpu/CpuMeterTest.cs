using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace NiceMeterTests.Meters.Cpu
{
    [TestClass]
    public class CpuMeterTest
    {
        [TestMethod]
        public void Ctor_ProvidedBaseCtorParameters_ShoulSetBaseCtorParameters()
        {
            var name = new Faker().Random.Word();

            var cpuMeter = new CpuMeter(name, new Mock<CpuConfig>().Object);

            Assert.AreEqual(name, cpuMeter.Name);
            Assert.AreEqual(HardwareType.CPU, cpuMeter.HardwareType);
        }

        [TestMethod]
        public void Ctor_AllFalseConfig_UnitsListShouldBeEmpty()
        {
            var cpuConfig = new CpuConfig
            {
                CpuTotal = false,
                CpuPackage = false,
                CpuTemp = false,
                CpuClock = false
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);

            Assert.AreEqual(false, cpuMeter.Units.Any());
        }

        [TestMethod]
        public void Ctor_NoConfigRequired_UnitOHNamesAreSetFromConsts()
        {
            var cpuConfig = new CpuConfig
            {
                CpuTotal = true,
                CpuPackage = true,
                CpuTemp = true,
                CpuClock = true
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);

            Assert.AreEqual(cpuMeter.CpuTotal.OHName, CpuMeter.CPU_TOTAL_OHNAME);
            Assert.AreEqual(cpuMeter.CpuPackage.OHName, CpuMeter.CPU_PACKAGE_OHNAME);
            Assert.AreEqual(cpuMeter.CpuTemp.OHName, CpuMeter.CPU_TEMP_OHNAME);
            Assert.AreEqual(cpuMeter.CpuClock.OHName, CpuMeter.CPU_CLOCK_OHNAME);
        }

        [TestMethod]
        public void Ctor_CpuTotalEnbaled_ShoulAddCpuTotalUnitToUnitsList()
        {
            var cpuConfig = new CpuConfig
            {
                CpuTotal = true,
                CpuPackage = false,
                CpuTemp = false,
                CpuClock = false
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);

            Assert.AreEqual(1, cpuMeter.Units.Count);
            Assert.IsInstanceOfType(cpuMeter.Units.First(), typeof(PercentUnit));
        }

        [TestMethod]
        public void Ctor_CpuPackageEnbaled_ShoulAddCpuPackageUnitToUnitsList()
        {
            var cpuConfig = new CpuConfig
            {
                CpuTotal = false,
                CpuPackage = true,
                CpuTemp = false,
                CpuClock = false
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);

            Assert.AreEqual(1, cpuMeter.Units.Count);
            Assert.IsInstanceOfType(cpuMeter.Units.First(), typeof(WattUnit));
        }

        [TestMethod]
        public void Ctor_CpuTempEnbaled_ShoulAddCpuTempUnitToUnitsList()
        {
            var cpuConfig = new CpuConfig
            {
                CpuTotal = false,
                CpuPackage = false,
                CpuTemp = true,
                CpuClock = false
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);

            Assert.AreEqual(1, cpuMeter.Units.Count);
            Assert.IsInstanceOfType(cpuMeter.Units.First(), typeof(TempUnit));
        }

        [TestMethod]
        public void Ctor_CpuClockEnbaled_ShoulAddCpuClockUnitToUnitsList()
        {
            var cpuConfig = new CpuConfig
            {
                CpuTotal = false,
                CpuPackage = false,
                CpuTemp = false,
                CpuClock = true
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);

            Assert.AreEqual(1, cpuMeter.Units.Count);
            Assert.IsInstanceOfType(cpuMeter.Units.First(), typeof(FreqUnit));
        }

        [TestMethod]
        public void UpdateMeters_NoMeters_ShoulSetMeterTextToNull()
        {
            var cpuConfig = new CpuConfig
            {
                CpuTotal = false,
                CpuPackage = false,
                CpuTemp = false,
                CpuClock = false
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);
            cpuMeter.UpdateMeters(new Mock<IHardware>().Object);

            Assert.IsNull(cpuMeter.Text);
        }

        [TestMethod]
        public void ReadSensors_CpuTotalEnabled_ShouldSetValueForCpuTotal()
        {
            var cpuTotalSensorValue = new Faker().Random.Number();
            var cpuTotalSensorMock = new Mock<ISensor>();
            cpuTotalSensorMock.SetupGet(x => x.Name).Returns(CpuMeter.CPU_TOTAL_OHNAME);
            cpuTotalSensorMock.SetupGet(x => x.Value).Returns(cpuTotalSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = cpuTotalSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var cpuConfig = new CpuConfig
            {
                CpuTotal = true,
                CpuPackage = false,
                CpuTemp = false,
                CpuClock = false
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);
            cpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            cpuTotalSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(cpuTotalSensorValue, cpuMeter.CpuTotal.Value);
        }

        [TestMethod]
        public void ReadSensors_CpuPackageEnabled_ShouldSetValueForCpuPackage()
        {
            var cpuPackageSensorValue = new Faker().Random.Number();
            var cpuPackageSensorMock = new Mock<ISensor>();
            cpuPackageSensorMock.SetupGet(x => x.Name).Returns(CpuMeter.CPU_PACKAGE_OHNAME);
            cpuPackageSensorMock.SetupGet(x => x.Value).Returns(cpuPackageSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = cpuPackageSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var cpuConfig = new CpuConfig
            {
                CpuTotal = false,
                CpuPackage = true,
                CpuTemp = false,
                CpuClock = false
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);
            cpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            cpuPackageSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(cpuPackageSensorValue, cpuMeter.CpuPackage.Value);
        }

        [TestMethod]
        public void ReadSensors_CpuTempEnabled_ShouldSetValueForCpuTemp()
        {
            var cpuTempSensorValue = new Faker().Random.Number();
            var cpuTempSensorMock = new Mock<ISensor>();
            cpuTempSensorMock.SetupGet(x => x.Name).Returns(CpuMeter.CPU_TEMP_OHNAME);
            cpuTempSensorMock.SetupGet(x => x.Value).Returns(cpuTempSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = cpuTempSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var cpuConfig = new CpuConfig
            {
                CpuTotal = false,
                CpuPackage = false,
                CpuTemp = true,
                CpuClock = false
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);
            cpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            cpuTempSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(cpuTempSensorValue, cpuMeter.CpuTemp.Value);
        }

        [TestMethod]
        public void ReadSensors_CpuClockEnabledSingleCore_ShouldSetValueForCpuClock()
        {
            var cpuClockSensorValue = new Faker().Random.Number();
            var cpuClockSensorMock = new Mock<ISensor>();
            cpuClockSensorMock.SetupGet(x => x.Name).Returns(CpuMeter.CPU_CLOCK_OHNAME);
            cpuClockSensorMock.SetupGet(x => x.Value).Returns(cpuClockSensorValue);
            cpuClockSensorMock.SetupGet(x => x.SensorType).Returns(SensorType.Clock);
            var sensors = new ISensor[1];
            sensors[0] = cpuClockSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var cpuConfig = new CpuConfig
            {
                CpuTotal = false,
                CpuPackage = false,
                CpuTemp = false,
                CpuClock = true
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);
            cpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            cpuClockSensorMock.VerifyGet(x => x.Value, Times.Once);
            cpuClockSensorMock.VerifyGet(x => x.SensorType, Times.Once);
            Assert.AreEqual(cpuClockSensorValue, cpuMeter.CpuClock.Value * 1000);
        }

        [TestMethod]
        public void ReadSensors_CpuClockEnabledMultiCore_ShouldSetValueForCpuClock()
        {
            var cpuClockSensorValue1 = 1000;
            var cpuClockSensorValue2 = 500;
            var cpuClockSensorsAverage = (cpuClockSensorValue1 + cpuClockSensorValue2) / 2; // We average multi core frequencies
            var cpuClockSensorMock1 = new Mock<ISensor>();
            cpuClockSensorMock1.SetupGet(x => x.Name).Returns(CpuMeter.CPU_CLOCK_OHNAME);
            cpuClockSensorMock1.SetupGet(x => x.Value).Returns(cpuClockSensorValue1);
            cpuClockSensorMock1.SetupGet(x => x.SensorType).Returns(SensorType.Clock);
            var cpuClockSensorMock2 = new Mock<ISensor>();
            cpuClockSensorMock2.SetupGet(x => x.Name).Returns(CpuMeter.CPU_CLOCK_OHNAME);
            cpuClockSensorMock2.SetupGet(x => x.Value).Returns(cpuClockSensorValue2);
            cpuClockSensorMock2.SetupGet(x => x.SensorType).Returns(SensorType.Clock);
            var sensors = new ISensor[2];
            sensors[0] = cpuClockSensorMock1.Object;
            sensors[1] = cpuClockSensorMock2.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var cpuConfig = new CpuConfig
            {
                CpuTotal = false,
                CpuPackage = false,
                CpuTemp = false,
                CpuClock = true
            };

            var cpuMeter = new CpuMeter(new Faker().Random.Word(), cpuConfig);
            cpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            cpuClockSensorMock1.VerifyGet(x => x.Value, Times.Once);
            cpuClockSensorMock1.VerifyGet(x => x.SensorType, Times.Once);
            Assert.AreEqual(cpuClockSensorsAverage, cpuMeter.CpuClock.Value * 1000); 
        }
    }
}
