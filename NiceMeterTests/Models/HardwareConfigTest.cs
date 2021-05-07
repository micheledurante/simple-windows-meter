using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Models;

namespace NiceMeterTests.Models
{
    [TestClass]
    public class HardwareConfigTest
    {
        [TestMethod]
        public void HardwareConfig_Default_AllHardwareShouldMatchSettingsFile()
        {
            var hardwareConfig = new HardwareConfig();

            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.MainboardEnabled, hardwareConfig.MainboardEnabled);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.CpuEnabled, hardwareConfig.CPUEnabled);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.RamEnabled, hardwareConfig.RAMEnabled);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.GpuEnabled, hardwareConfig.GPUEnabled);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.FanControllerEnabled, hardwareConfig.FanControllerEnabled);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.HddEnabled, hardwareConfig.HDDEnabled);
        }
    }
}
