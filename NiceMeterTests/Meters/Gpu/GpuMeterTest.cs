using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Meters.Gpu;
using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace NiceMeterTests.Meters.Cpu
{
    [TestClass]
    public class GpuMeterTest
    {
        [TestMethod]
        public void Ctor_ProvidedBaseAtiGpuCtorParameters_ShoulSetBaseAtiGpuCtorParameters()
        {
            var name = new Faker().Random.Word();

            var gpuMeter = new GpuMeter(name, HardwareType.GpuAti, new Mock<GpuConfig>().Object);

            Assert.AreEqual(name, gpuMeter.Name);
            Assert.AreEqual(HardwareType.GpuAti, gpuMeter.HardwareType);
        }

        [TestMethod]
        public void Ctor_AllFalseConfig_UnitsListShouldBeEmpty()
        {
            var gpuConfig = new GpuConfig 
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), HardwareType.GpuAti, gpuConfig);

            Assert.AreEqual(false, gpuMeter.Units.Any());
        }

        [TestMethod]
        public void Ctor_NoConfigRequired_UnitOHNamesAreSetFromConsts()
        {
            var gpuMeter = new GpuMeter(new Faker().Random.Word(), HardwareType.GpuAti, new Mock<GpuConfig>().Object);

            Assert.AreEqual(gpuMeter.GpuCore.OHName, GpuMeter.GPU_CORE_OHNAME);
            Assert.AreEqual(gpuMeter.GpuMemory.OHName, GpuMeter.GPU_MEMORY_OHNAME);
            Assert.AreEqual(gpuMeter.GpuShader.OHName, GpuMeter.GPU_SHADER_OHNAME);
            Assert.AreEqual(gpuMeter.GpuCoreLoad.OHName, GpuMeter.GPU_CORE_LOAD_OHNAME);
            Assert.AreEqual(gpuMeter.GpuTemp.OHName, GpuMeter.GPU_TEMP_OHNAME);
            Assert.AreEqual(gpuMeter.GpuMemoryLoad.OHName, GpuMeter.GPU_MEMORY_LOAD_OHNAME);
            Assert.AreEqual(gpuMeter.GpuMemoryTotal.OHName, GpuMeter.GPU_MEMORY_TOTAL_OHNAME);
            Assert.AreEqual(gpuMeter.GpuMemoryUsed.OHName, GpuMeter.GPU_MEMORY_USED_OHNAME);
            Assert.AreEqual(gpuMeter.GpuMemoryFree.OHName, GpuMeter.GPU_MEMORY_FREE_OHNAME);
        }

        [TestMethod]
        public void Ctor_ProvidedBaseNvidiaGpuCtorParameters_ShoulSetBaseNvidiaGpuCtorParameters()
        {
            var gpuConfig = new GpuConfig 
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };
            var name = new Faker().Random.Word();

            var gpuMeter = new GpuMeter(name, HardwareType.GpuNvidia, gpuConfig);

            Assert.AreEqual(name, gpuMeter.Name);
            Assert.AreEqual(HardwareType.GpuNvidia, gpuMeter.HardwareType);
            Assert.AreEqual(false, gpuMeter.Units.Any());
        }

        [TestMethod]
        public void Ctor_GpuCoreEnabled_ShoulAddGpuCoreUnitToUnitsList()
        {
            var gpuConfig = new GpuConfig
            {
                GpuCore = true,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(FreqUnit));
        }

        [TestMethod]
        public void Ctor_GpuMemoryEnabled_ShoulAddGpuMemoryUnitToUnitsList()
        {
            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = true,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(FreqUnit));
        }

        [TestMethod]
        public void Ctor_GpuShaderEnabled_ShoulAddGpuShaderUnitToUnitsList()
        {
            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = true,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(FreqUnit));
        }

        [TestMethod]
        public void Ctor_GpuCoreLoadEnabled_ShoulAddGpuCoreLoadUnitToUnitsList()
        {
            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = true,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(PercentUnit));
        }

        [TestMethod]
        public void Ctor_GpuTempEnabled_ShoulAddGpuTempUnitToUnitsList()
        {
            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = true,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(TempUnit));
        }

        [TestMethod]
        public void Ctor_GpuMemoryLoadEnabled_ShoulAddGpuMemoryLoadUnitToUnitsList()
        {
            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = true,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(PercentUnit));
        }

        [TestMethod]
        public void Ctor_GpuMemoryTotalEnabled_ShoulAddGpuMemoryTotalUnitToUnitsList()
        {
            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = true,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(GbUnit));
        }

        [TestMethod]
        public void Ctor_GpuMemoryUsedEnabled_ShoulAddGpuMemoryUsedUnitToUnitsList()
        {
            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = true,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(GbUnit));
        }

        [TestMethod]
        public void Ctor_GpuMemoryFreeEnabled_ShoulAddGpuMemoryFreeUnitToUnitsList()
        {
            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = true
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(GbUnit));
        }

        [TestMethod]
        public void UpdateMeters_NoMeters_ShoulSetMeterTextToNull()
        {
            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);
            gpuMeter.UpdateMeters(new Mock<IHardware>().Object);

            Assert.IsNull(gpuMeter.Text);
        }

        [TestMethod]
        public void ReadSensors_GpuCoreEnabled_ShouldSetValueForGpuCore()
        {
            var gpuCoreSensorValue = new Faker().Random.Number();
            var gpuCoreSensorMock = new Mock<ISensor>();
            gpuCoreSensorMock.SetupGet(x => x.Name).Returns(GpuMeter.GPU_CORE_OHNAME);
            gpuCoreSensorMock.SetupGet(x => x.Value).Returns(gpuCoreSensorValue);
            gpuCoreSensorMock.SetupGet(x => x.SensorType).Returns(SensorType.Clock);
            var sensors = new ISensor[1];
            sensors[0] = gpuCoreSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var gpuConfig = new GpuConfig
            {
                GpuCore = true,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);
            gpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            gpuCoreSensorMock.VerifyGet(x => x.Value, Times.Once);
            gpuCoreSensorMock.VerifyGet(x => x.SensorType, Times.Once);
            Assert.AreEqual(gpuCoreSensorValue, gpuMeter.GpuCore.Value * 1000);
        }

        [TestMethod]
        public void ReadSensors_GpuMemoryEnabled_ShouldSetValueForGpuMemory()
        {
            var gpuMemorySensorValue = new Faker().Random.Number();
            var gpuMemorySensorMock = new Mock<ISensor>();
            gpuMemorySensorMock.SetupGet(x => x.Name).Returns(GpuMeter.GPU_MEMORY_OHNAME);
            gpuMemorySensorMock.SetupGet(x => x.Value).Returns(gpuMemorySensorValue);
            gpuMemorySensorMock.SetupGet(x => x.SensorType).Returns(SensorType.Clock);
            var sensors = new ISensor[1];
            sensors[0] = gpuMemorySensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = true,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);
            gpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            gpuMemorySensorMock.VerifyGet(x => x.Value, Times.Once);
            gpuMemorySensorMock.VerifyGet(x => x.SensorType, Times.Once);
            Assert.AreEqual(gpuMemorySensorValue, gpuMeter.GpuMemory.Value * 1000);
        }

        [TestMethod]
        public void ReadSensors_GpuShaderEnabled_ShouldSetValueForGpuShader()
        {
            var gpuShaderSensorValue = new Faker().Random.Number();
            var gpuShaderSensorMock = new Mock<ISensor>();
            gpuShaderSensorMock.SetupGet(x => x.Name).Returns(GpuMeter.GPU_SHADER_OHNAME);
            gpuShaderSensorMock.SetupGet(x => x.Value).Returns(gpuShaderSensorValue);
            gpuShaderSensorMock.SetupGet(x => x.SensorType).Returns(SensorType.Clock);
            var sensors = new ISensor[1];
            sensors[0] = gpuShaderSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = true,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);
            gpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            gpuShaderSensorMock.VerifyGet(x => x.Value, Times.Once);
            gpuShaderSensorMock.VerifyGet(x => x.SensorType, Times.Once);
            Assert.AreEqual(gpuShaderSensorValue, gpuMeter.GpuShader.Value * 1000);
        }

        [TestMethod]
        public void ReadSensors_GpuCoreLoadEnabled_ShouldSetValueForGpuCoreLoad()
        {
            var gpuCoreLoadSensorValue = new Faker().Random.Number();
            var gpuCoreLoadSensorMock = new Mock<ISensor>();
            gpuCoreLoadSensorMock.SetupGet(x => x.Name).Returns(GpuMeter.GPU_CORE_LOAD_OHNAME);
            gpuCoreLoadSensorMock.SetupGet(x => x.Value).Returns(gpuCoreLoadSensorValue);
            gpuCoreLoadSensorMock.SetupGet(x => x.SensorType).Returns(SensorType.Load);
            var sensors = new ISensor[1];
            sensors[0] = gpuCoreLoadSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = true,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);
            gpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            gpuCoreLoadSensorMock.VerifyGet(x => x.Value, Times.Once);
            gpuCoreLoadSensorMock.VerifyGet(x => x.SensorType, Times.Once);
            Assert.AreEqual(gpuCoreLoadSensorValue, gpuMeter.GpuCoreLoad.Value);
        }

        [TestMethod]
        public void ReadSensors_GpuTempEnabled_ShouldSetValueForGpuTemp()
        {
            var gpuTempSensorValue = new Faker().Random.Number();
            var gpuTempSensorMock = new Mock<ISensor>();
            gpuTempSensorMock.SetupGet(x => x.Name).Returns(GpuMeter.GPU_TEMP_OHNAME);
            gpuTempSensorMock.SetupGet(x => x.Value).Returns(gpuTempSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = gpuTempSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = true,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);
            gpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            gpuTempSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(gpuTempSensorValue, gpuMeter.GpuTemp.Value);
        }

        [TestMethod]
        public void ReadSensors_GpuMemoryLoadEnabled_ShouldSetValueForGpuMemoryLoad()
        {
            var gpuMemoryLoadSensorValue = new Faker().Random.Number();
            var gpuMemoryLoadSensorMock = new Mock<ISensor>();
            gpuMemoryLoadSensorMock.SetupGet(x => x.Name).Returns(GpuMeter.GPU_MEMORY_LOAD_OHNAME);
            gpuMemoryLoadSensorMock.SetupGet(x => x.Value).Returns(gpuMemoryLoadSensorValue);
            gpuMemoryLoadSensorMock.SetupGet(x => x.SensorType).Returns(SensorType.Load);
            var sensors = new ISensor[1];
            sensors[0] = gpuMemoryLoadSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = true,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);
            gpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            gpuMemoryLoadSensorMock.VerifyGet(x => x.Value, Times.Once);
            gpuMemoryLoadSensorMock.VerifyGet(x => x.SensorType, Times.Once);
            Assert.AreEqual(gpuMemoryLoadSensorValue, gpuMeter.GpuMemoryLoad.Value);
        }

        [TestMethod]
        public void ReadSensors_GpuMemoryTotalEnabled_ShouldSetValueForGpuMemoryTotal()
        {
            var gpuMemoryTotalSensorValue = new Faker().Random.Number();
            var gpuMemoryTotalSensorMock = new Mock<ISensor>();
            gpuMemoryTotalSensorMock.SetupGet(x => x.Name).Returns(GpuMeter.GPU_MEMORY_TOTAL_OHNAME);
            gpuMemoryTotalSensorMock.SetupGet(x => x.Value).Returns(gpuMemoryTotalSensorValue);
            gpuMemoryTotalSensorMock.SetupGet(x => x.SensorType).Returns(SensorType.Load);
            var sensors = new ISensor[1];
            sensors[0] = gpuMemoryTotalSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = true,
                GpuMemoryUsed = false,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);
            gpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            gpuMemoryTotalSensorMock.VerifyGet(x => x.Value, Times.Once);
            gpuMemoryTotalSensorMock.VerifyGet(x => x.SensorType, Times.Once);
            Assert.AreEqual(gpuMemoryTotalSensorValue, gpuMeter.GpuMemoryTotal.Value * 1000);
        }

        [TestMethod]
        public void ReadSensors_GpuMemoryUsedEnabled_ShouldSetValueForGpuMemoryUsed()
        {
            var gpuMemoryUsedSensorValue = new Faker().Random.Number();
            var gpuMemoryUsedSensorMock = new Mock<ISensor>();
            gpuMemoryUsedSensorMock.SetupGet(x => x.Name).Returns(GpuMeter.GPU_MEMORY_USED_OHNAME);
            gpuMemoryUsedSensorMock.SetupGet(x => x.Value).Returns(gpuMemoryUsedSensorValue);
            gpuMemoryUsedSensorMock.SetupGet(x => x.SensorType).Returns(SensorType.Load);
            var sensors = new ISensor[1];
            sensors[0] = gpuMemoryUsedSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = true,
                GpuMemoryFree = false
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);
            gpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            gpuMemoryUsedSensorMock.VerifyGet(x => x.Value, Times.Once);
            gpuMemoryUsedSensorMock.VerifyGet(x => x.SensorType, Times.Once);
            Assert.AreEqual(gpuMemoryUsedSensorValue, gpuMeter.GpuMemoryUsed.Value * 1000);
        }

        [TestMethod]
        public void ReadSensors_GpuMemoryFreeEnabled_ShouldSetValueForGpuMemoryFree()
        {
            var GpuMemoryFreeSensorValue = new Faker().Random.Number();
            var GpuMemoryFreeSensorMock = new Mock<ISensor>();
            GpuMemoryFreeSensorMock.SetupGet(x => x.Name).Returns(GpuMeter.GPU_MEMORY_FREE_OHNAME);
            GpuMemoryFreeSensorMock.SetupGet(x => x.Value).Returns(GpuMemoryFreeSensorValue);
            GpuMemoryFreeSensorMock.SetupGet(x => x.SensorType).Returns(SensorType.Load);
            var sensors = new ISensor[1];
            sensors[0] = GpuMemoryFreeSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var gpuConfig = new GpuConfig
            {
                GpuCore = false,
                GpuMemory = false,
                GpuShader = false,
                GpuCoreLoad = false,
                GpuTemp = false,
                GpuMemoryLoad = false,
                GpuMemoryTotal = false,
                GpuMemoryUsed = false,
                GpuMemoryFree = true
            };

            var gpuMeter = new GpuMeter(new Faker().Random.Word(), (HardwareType)123, gpuConfig);
            gpuMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            GpuMemoryFreeSensorMock.VerifyGet(x => x.Value, Times.Once);
            GpuMemoryFreeSensorMock.VerifyGet(x => x.SensorType, Times.Once);
            Assert.AreEqual(GpuMemoryFreeSensorValue, gpuMeter.GpuMemoryFree.Value * 1000);
        }
    }
}
