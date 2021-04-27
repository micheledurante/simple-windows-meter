using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Models;

namespace NiceMeterTests.Models
{
    [TestClass]
    public class ComputerTest
    {
        [TestMethod]
        public void Computer_Constructor_TestBaseComputerInheritance()
        {
            var computer = new Computer();
            Assert.IsInstanceOfType(computer, typeof(OpenHardwareMonitor.Hardware.Computer));
            Assert.IsInstanceOfType(computer, typeof(IComputer));
        }
    }
}
