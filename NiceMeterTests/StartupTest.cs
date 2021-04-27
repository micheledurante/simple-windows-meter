using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter;
using OpenHardwareMonitor.Hardware;

namespace NiceMeterTests
{
    [TestClass]
    public class StartupTest
    {
        [TestMethod]
        public void GetComputer_Computer_ShouldReturnTheExpectedComputerAndItsDevices()
        {
            var startup = new Startup();
            var computer = startup.GetComputer();

            Assert.IsInstanceOfType(computer, typeof(Computer));
            Assert.IsTrue(computer.MainboardEnabled);
            Assert.IsTrue(computer.CPUEnabled);
            Assert.IsTrue(computer.RAMEnabled);
            Assert.IsTrue(computer.GPUEnabled);
            Assert.IsTrue(computer.FanControllerEnabled);
            Assert.IsTrue(computer.HDDEnabled);
        }
    }
}
