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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("qwerty", HardwareType.GpuAti, gpuConfig);

            Assert.AreEqual("qwerty", gpuMeter.Name);
            Assert.AreEqual(HardwareType.GpuAti, gpuMeter.HardwareType);
            Assert.AreEqual(false, gpuMeter.Units.Any());
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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("vcxz", HardwareType.GpuNvidia, gpuConfig);

            Assert.AreEqual("vcxz", gpuMeter.Name);
            Assert.AreEqual(HardwareType.GpuNvidia, gpuMeter.HardwareType);
            Assert.AreEqual(false, gpuMeter.Units.Any());
        }

        [TestMethod]
        public void Ctor_GpuCoreEnbaled_ShoulAddGpuCoreUnitToUnitsList()
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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("sa", (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(FreqUnit));
        }

        [TestMethod]
        public void Ctor_GpuMemoryEnbaled_ShoulAddGpuMemoryUnitToUnitsList()
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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("asd", (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(FreqUnit));
        }

        [TestMethod]
        public void Ctor_GpuShaderEnbaled_ShoulAddGpuShaderUnitToUnitsList()
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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("zxcv", (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(FreqUnit));
        }

        [TestMethod]
        public void Ctor_GpuCoreLoadEnbaled_ShoulAddGpuCoreLoadUnitToUnitsList()
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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("zxcv", (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(PercentUnit));
        }

        [TestMethod]
        public void Ctor_GpuTempEnbaled_ShoulAddGpuTempUnitToUnitsList()
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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("zxcv", (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(TempUnit));
        }

        [TestMethod]
        public void Ctor_GpuMemoryLoadEnbaled_ShoulAddGpuMemoryLoadUnitToUnitsList()
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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("zxcv", (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(PercentUnit));
        }

        [TestMethod]
        public void Ctor_GpuMemoryTotalEnbaled_ShoulAddGpuMemoryTotalUnitToUnitsList()
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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("fdsa", (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(GbUnit));
        }

        [TestMethod]
        public void Ctor_GpuMemoryUsedEnbaled_ShoulAddGpuMemoryUsedUnitToUnitsList()
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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("qwerty", (HardwareType)123, gpuConfig);

            Assert.AreEqual(1, gpuMeter.Units.Count);
            Assert.IsInstanceOfType(gpuMeter.Units.First(), typeof(GbUnit));
        }

        [TestMethod]
        public void Ctor_GpuMemoryFreeEnbaled_ShoulAddGpuMemoryFreeUnitToUnitsList()
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
                GpuMemoryFree = true,
            };

            var gpuMeter = new GpuMeter("sda", (HardwareType)123, gpuConfig);

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
                GpuMemoryFree = false,
            };

            var gpuMeter = new GpuMeter("asdfgh", (HardwareType)123, gpuConfig);
            gpuMeter.UpdateMeters(new Mock<IHardware>().Object);

            Assert.IsNull(gpuMeter.Text);
        }
    }
}
