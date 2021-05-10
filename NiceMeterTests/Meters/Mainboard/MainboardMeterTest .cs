using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Meters.Mainboard;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace NiceMeterTests.Meters.Mainboard
{
    [TestClass]
    public class MainboardMeterTest
    {
        [TestMethod]
        public void Ctor_ProvidedBaseCtorParameters_ShoulSetBaseCtorParameters()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardMeter("asd", mainboardConfig);

            Assert.AreEqual("asd", mainboardMeter.Name);
            Assert.AreEqual(HardwareType.Mainboard, mainboardMeter.HardwareType);
        }

        [TestMethod]
        public void UpdateMeters_NoMeters_ShoulSetMeterTextToNull()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardMeter("ytrewq", mainboardConfig);
            mainboardMeter.UpdateMeters(new Mock<IHardware>().Object);

            Assert.IsNull(mainboardMeter.Text);
        }
    }
}
