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

            Assert.IsInstanceOfType(computer, typeof(IComputer));
            Assert.IsTrue(computer.MainboardEnabled);
            Assert.IsFalse(computer.CPUEnabled);
            Assert.IsFalse(computer.RAMEnabled);
            Assert.IsTrue(computer.GPUEnabled);
            Assert.IsFalse(computer.FanControllerEnabled);
            Assert.IsFalse(computer.HDDEnabled);
        }

        [TestMethod]
        public void GetAllHardware_Default_ShouldEnableAllHardware()
        {
            var computers = new Computers();
            var computer = computers.GetAllHardware();

            Assert.IsInstanceOfType(computer, typeof(IComputer));
            Assert.IsTrue(computer.MainboardEnabled);
            Assert.IsTrue(computer.CPUEnabled);
            Assert.IsTrue(computer.RAMEnabled);
            Assert.IsTrue(computer.GPUEnabled);
            Assert.IsTrue(computer.FanControllerEnabled);
            Assert.IsTrue(computer.HDDEnabled);
        }
    }
}
