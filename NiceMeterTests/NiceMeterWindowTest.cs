using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter;
using NiceMeter.Interfaces;

namespace NiceMeterTests
{
    [TestClass]
    public class NiceMeterWindowTest
    {
        [TestMethod]
        public void SetWindowProperties_DefaultProperties_DefaultPropertiesMatchExpectations()
        {
            var observableMetersMock = new Mock<IObservableMeters>();
            double workAreaRight = 123;
            var window = new NiceMeterWindow(observableMetersMock.Object, workAreaRight);

            Assert.AreEqual(NiceMeterWindow.height, window.Height);
            Assert.AreEqual(NiceMeterWindow.left, window.Left);
            Assert.AreEqual(NiceMeterWindow.top, window.Top);
            Assert.AreEqual(workAreaRight, window.Width);
            Assert.AreEqual(NiceMeterWindow.title, window.Title);
            Assert.AreEqual(NiceMeterWindow.allowsTransparency, window.AllowsTransparency);
            Assert.AreEqual(NiceMeterWindow.windowStyle, window.WindowStyle);
            Assert.AreEqual(NiceMeterWindow.resizeMode, window.ResizeMode);
            Assert.AreEqual(NiceMeterWindow.windowStartupLocation, window.WindowStartupLocation);
        }
    }
}
