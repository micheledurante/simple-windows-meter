using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Meters.Mainboard;
using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace NiceMeterTests.Meters.Mainboard
{
    [TestClass]
    public class MainboardSubHardwareMeterTest
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

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter("qwerty", mainboardConfig);

            Assert.AreEqual("qwerty", mainboardSubHardwareMeter.Name);
            Assert.AreEqual(HardwareType.SuperIO, mainboardSubHardwareMeter.HardwareType);
            Assert.AreEqual(false, mainboardSubHardwareMeter.Units.Any());
        }

        [TestMethod]
        public void Ctor_MainboardCpuVCoreEnbaled_ShoulAddMainboardCpuVCoreUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = true,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter("fdsa", mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(VoltUnit));
        }

        [TestMethod]
        public void Ctor_MainboardCpuSocEnbaled_ShoulAddMainboardCpuSocUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = true,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter("rty", mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(VoltUnit));
        }

        [TestMethod]
        public void Ctor_MainboardDRamEnbaled_ShoulAddMainboardDRamUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = true,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter("qwe", mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(VoltUnit));
        }

        [TestMethod]
        public void Ctor_MainboardVrm_ShoulAddMainboardVrmUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = true,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter("sda", mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(TempUnit));
        }

        [TestMethod]
        public void Ctor_MainboardTSensor_ShoulAddMainboardTSensorUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = true,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter("dsa", mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(TempUnit));
        }

        [TestMethod]
        public void Ctor_MainboardCpuFan_ShoulAddMainboardCpuFanUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = true,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter("zxcv", mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(RpmUnit));
        }

        [TestMethod]
        public void Ctor_MainboardWPump_ShoulAddMainboardWPumpUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = true
            };

            var mainboardMeter = new MainboardSubHardwareMeter("asdf", mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(RpmUnit));
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

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter("asdf", mainboardConfig);
            mainboardSubHardwareMeter.UpdateMeters(new Mock<IHardware>().Object);

            Assert.IsNull(mainboardSubHardwareMeter.Text);
        }
    }
}
