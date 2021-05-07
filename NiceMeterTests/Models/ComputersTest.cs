using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Models;

namespace NiceMeterTests.Models
{
    [TestClass]
    public class ComputersTest
    {
        [TestMethod]
        public void GetHardware_Default_ShouldReturnAComputer()
        {
            var computers = new Computers();
            var computer = computers.GetHardware();

            Assert.IsInstanceOfType(computer, typeof(IComputerModel));
        }
    }
}
