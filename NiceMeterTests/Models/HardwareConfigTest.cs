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
    }
}
