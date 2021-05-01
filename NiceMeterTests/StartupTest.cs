using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter;
using NiceMeter.ViewModels;
using NiceMeter.Models;
using System;
using System.Windows.Threading;

namespace NiceMeterTests
{
    [TestClass]
    public class StartupTest
    {
        private static Startup startup;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            startup = new Startup(); // There can only be one instance of a window class
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            startup = null;
        }

        [TestMethod]
        public void GetComputer_Computer_ShouldReturnTheExpectedComputerAndItsDevices()
        {
            var computers = new Mock<Computers>();

            var computer = startup.GetComputer(computers.Object);
            Assert.IsInstanceOfType(computer, typeof(IComputer));
        }

        [TestMethod]
        public void CreateObservableMeters_ValidComputer_WillOpenComputerAndCreateMeters()
        {
            var computerMock = new Mock<IComputer>();
            var computerVisitorMock = new Mock<IVisitorObservable>();

            var observableMeters = startup.CreateObservableMeters(computerMock.Object, computerVisitorMock.Object);

            computerMock.Verify(x => x.Open(), Times.Once);
            computerMock.Verify(x => x.Traverse(computerVisitorMock.Object), Times.Once);
            computerVisitorMock.Verify(x => x.ConvertMeters(), Times.Once);
            Assert.IsInstanceOfType(observableMeters, typeof(IObservableMeters));
        }

        [TestMethod]
        public void CreateTimeSpan_DefaultInterval_ShouldBeCreatedWithDefaultTimes()
        {
            var interval = startup.CreateTimeSpan();
            Assert.IsInstanceOfType(interval, typeof(TimeSpan));
            Assert.AreEqual(Startup.TimerHours, interval.Hours);
            Assert.AreEqual(Startup.TimerMinutes, interval.Minutes);
            Assert.AreEqual(Startup.TimerSeconds, interval.Seconds);
        }

        [TestMethod]
        public void CreateTimer_DefaultTimer_ShouldBeCreatedWithDefaultValues()
        {
            var timerMock = new Mock<DispatcherTimer>();
            var computerMock = new Mock<IComputer>();
            var computerVisitorMock = new Mock<IVisitorObservable>();

            startup.CreateTimer(computerMock.Object, computerVisitorMock.Object, timerMock.Object);
            Assert.IsInstanceOfType(timerMock.Object.Interval, typeof(TimeSpan));
        }
    }
}
