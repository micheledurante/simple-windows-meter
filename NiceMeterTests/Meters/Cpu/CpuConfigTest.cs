using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Cpu;

namespace NiceMeterTests.Meters.Cpu
{
    [TestClass]
    public class CpuConfigTest
    {
        [TestMethod]
        public void Ctor_Default_AllHardwareShouldMatchSettingsFile()
        {
            var cpuConfig = new CpuConfig();

            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.CpuTotal, cpuConfig.CpuTotal);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.CpuPackage, cpuConfig.CpuPackage);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.CpuClock, cpuConfig.CpuClock);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.CpuTemp, cpuConfig.CpuTemp);
        }
    }
}
