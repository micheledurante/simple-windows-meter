using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Models;

namespace NiceMeterTests.Models
{
    [TestClass]
    public class HardwareConfigTest
    {
        [TestMethod]
        public void HardwareConfig_Default_AllHardwareShouldBeDisabled()
        {
            var hardwareConfig = new HardwareConfig();

            Assert.IsFalse(hardwareConfig.MainboardEnabled);
            Assert.IsFalse(hardwareConfig.CPUEnabled);
            Assert.IsFalse(hardwareConfig.RAMEnabled);
            Assert.IsFalse(hardwareConfig.GPUEnabled);
            Assert.IsFalse(hardwareConfig.FanControllerEnabled);
            Assert.IsFalse(hardwareConfig.HDDEnabled);
        }

        [TestMethod]
        public void AllHardwareConfig_Default_AllHardwareShouldBeEnabled()
        {
            var hardwareConfig = new HardwareConfig().AllHardwareConfig();

            Assert.IsTrue(hardwareConfig.MainboardEnabled);
            Assert.IsTrue(hardwareConfig.CPUEnabled);
            Assert.IsTrue(hardwareConfig.RAMEnabled);
            Assert.IsTrue(hardwareConfig.GPUEnabled);
            Assert.IsTrue(hardwareConfig.FanControllerEnabled);
            Assert.IsTrue(hardwareConfig.HDDEnabled);
        }

        [TestMethod]
        public void TestingHardwareConfig_Default_OnlyCertainHardwareShouldBeEnabled()
        {
            var hardwareConfig = new HardwareConfig().TestingHardwareConfig();

            Assert.IsTrue(hardwareConfig.MainboardEnabled);
            Assert.IsTrue(hardwareConfig.CPUEnabled);
            Assert.IsFalse(hardwareConfig.RAMEnabled);
            Assert.IsFalse(hardwareConfig.GPUEnabled);
            Assert.IsFalse(hardwareConfig.FanControllerEnabled);
            Assert.IsFalse(hardwareConfig.HDDEnabled);
        }
    }
}
