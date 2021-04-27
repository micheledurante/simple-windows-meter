using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter;
using NiceMeter.Meter;
using NiceMeter.Models;
using NiceMeter.ViewModels;

namespace NiceMeterTests
{
    [TestClass]
    public class StartupTest
    {
        private static Startup startup;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            startup = new Startup();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            startup = null;
        }

        [TestMethod]
        public void GetComputer_Computer_ShouldReturnTheExpectedComputerAndItsDevices()
        {
            var computer = startup.GetComputer();

            Assert.IsInstanceOfType(computer, typeof(IComputer));
            Assert.IsTrue(computer.MainboardEnabled);
            Assert.IsTrue(computer.CPUEnabled);
            Assert.IsTrue(computer.RAMEnabled);
            Assert.IsTrue(computer.GPUEnabled);
            Assert.IsTrue(computer.FanControllerEnabled);
            Assert.IsTrue(computer.HDDEnabled);
        }

        [TestMethod]
        public void StartObservableMeters_ValidComputer_WillOpenComputerAndCreateMeters()
        {
            var computerMock = new Mock<IComputer>();
            var computerVisitorMock = new Mock<IVisitorObservable>();

            var observableMeters = startup.StartObservableMeters(computerMock.Object, computerVisitorMock.Object);

            computerMock.Verify(x => x.Open(), Times.Once);
            computerMock.Verify(x => x.Traverse(computerVisitorMock.Object), Times.Once);
            computerVisitorMock.Verify(x => x.GetDisplayMeters(), Times.Once);
            Assert.IsInstanceOfType(observableMeters, typeof(IObservableMeters));
        }
    }
}
