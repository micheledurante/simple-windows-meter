using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Gpu;

namespace NiceMeterTests.Meters.Gpu
{
    [TestClass]
    public class GpuConfigTest
    {
        [TestMethod]
        public void Ctor_Default_AllHardwareShouldMatchSettingsFile()
        {
            var gpuConfig = new GpuConfig();

            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.GpuCore, gpuConfig.GpuCore);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.GpuMemory, gpuConfig.GpuMemory);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.GpuShader, gpuConfig.GpuShader);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.GpuCoreLoad, gpuConfig.GpuCoreLoad);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.GpuTemp, gpuConfig.GpuTemp);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.GpuMemoryLoad, gpuConfig.GpuMemoryLoad);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.GpuMemoryTotal, gpuConfig.GpuMemoryTotal);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.GpuMemoryUsed, gpuConfig.GpuMemoryUsed);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.GpuMemoryFree, gpuConfig.GpuMemoryFree);
        }
    }
}
