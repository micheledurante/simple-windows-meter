using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Mainboard;

namespace NiceMeterTests.Meters.Mainboard
{
    [TestClass]
    public class MainboardConfigTest
    {
        [TestMethod]
        public void Ctor_Default_AllHardwareShouldMatchSettingsFile()
        {
            var mainboardConfig = new MainboardConfig();

            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.MainboardCpuVCore, mainboardConfig.MainboardCpuVCore);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.MainboardCpuSoc, mainboardConfig.MainboardCpuSoc);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.MainboardDRam, mainboardConfig.MainboardDRam);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.MainboardVrm, mainboardConfig.MainboardVrm);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.MainboardTSensor, mainboardConfig.MainboardTSensor);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.MainboardCpuFan, mainboardConfig.MainboardCpuFan);
            Assert.AreEqual(NiceMeter.Properties.NiceMeter.Default.MainboardWPump, mainboardConfig.MainboardWPump);
        }
    }
}
