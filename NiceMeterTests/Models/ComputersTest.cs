using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Models;

namespace NiceMeterTests.Models
{
    [TestClass]
    public class ComputersTest
    {
        [TestMethod]
        public void GetTestingHardware_Default_ShouldEnableTestingHardware()
        {
            var computers = new Computers();
            var computer = computers.GetTestingHardware();
            var hardwareConfig = HardwareConfig.TestingHardwareConfig();

            Assert.IsInstanceOfType(computer, typeof(IComputerModel));
            Assert.AreEqual(hardwareConfig.MainboardEnabled, computer.MainboardEnabled);
            Assert.AreEqual(hardwareConfig.CPUEnabled, computer.CPUEnabled);
            Assert.AreEqual(hardwareConfig.RAMEnabled, computer.RAMEnabled);
            Assert.AreEqual(hardwareConfig.GPUEnabled, computer.GPUEnabled);
            Assert.AreEqual(hardwareConfig.FanControllerEnabled, computer.FanControllerEnabled);
            Assert.AreEqual(hardwareConfig.HDDEnabled, computer.HDDEnabled);
        }

        [TestMethod]
        public void GetAllHardware_Default_ShouldEnableAllHardware()
        {
            var computers = new Computers();
            var computer = computers.GetAllHardware();
            var hardwareConfig = HardwareConfig.AllHardwareConfig();

            Assert.IsInstanceOfType(computer, typeof(IComputerModel));
            Assert.AreEqual(hardwareConfig.MainboardEnabled, computer.MainboardEnabled);
            Assert.AreEqual(hardwareConfig.CPUEnabled, computer.CPUEnabled);
            Assert.AreEqual(hardwareConfig.RAMEnabled, computer.RAMEnabled);
            Assert.AreEqual(hardwareConfig.GPUEnabled, computer.GPUEnabled);
            Assert.AreEqual(hardwareConfig.FanControllerEnabled, computer.FanControllerEnabled);
            Assert.AreEqual(hardwareConfig.HDDEnabled, computer.HDDEnabled);
        }
    }
}
