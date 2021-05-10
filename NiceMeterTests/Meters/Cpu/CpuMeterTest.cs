using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace NiceMeterTests.Meters.Cpu
{
    [TestClass]
    public class CpuMeterTest
    {
        [TestMethod]
        public void Ctor_ProvidedBaseCtorParameters_ShoulSetBaseCtorParameters()
        {
            var cpuConfig = new CpuConfig { CpuTotal = false, CpuPackage = false, CpuTemp = false, CpuClock = false };

            var cpuMeter = new CpuMeter("asd", cpuConfig);

            Assert.AreEqual("asd", cpuMeter.Name);
            Assert.AreEqual(HardwareType.CPU, cpuMeter.HardwareType);
            Assert.AreEqual(false, cpuMeter.Units.Any());
        }

        [TestMethod]
        public void Ctor_CpuTotalEnbaled_ShoulAddCpuTotalUnitToUnitsList()
        {
            var cpuConfig = new CpuConfig { CpuTotal = true, CpuPackage = false, CpuTemp = false, CpuClock = false };

            var cpuMeter = new CpuMeter("asdf", cpuConfig);

            Assert.AreEqual(1, cpuMeter.Units.Count);
            Assert.IsInstanceOfType(cpuMeter.Units.First(), typeof(PercentUnit));
        }

        [TestMethod]
        public void Ctor_CpuPackageEnbaled_ShoulAddCpuPackageUnitToUnitsList()
        {
            var cpuConfig = new CpuConfig { CpuTotal = false, CpuPackage = true, CpuTemp = false, CpuClock = false };
           
            var cpuMeter = new CpuMeter("zxcv", cpuConfig);

            Assert.AreEqual(1, cpuMeter.Units.Count);
            Assert.IsInstanceOfType(cpuMeter.Units.First(), typeof(WattUnit));
        }

        [TestMethod]
        public void Ctor_CpuTempEnbaled_ShoulAddCpuTempUnitToUnitsList()
        {
            var cpuConfig = new CpuConfig { CpuTotal = false, CpuPackage = false, CpuTemp = true, CpuClock = false };
           
            var cpuMeter = new CpuMeter("vcxz", cpuConfig);

            Assert.AreEqual(1, cpuMeter.Units.Count);
            Assert.IsInstanceOfType(cpuMeter.Units.First(), typeof(TempUnit));
        }

        [TestMethod]
        public void Ctor_CpuClockEnbaled_ShoulAddCpuClockUnitToUnitsList()
        {
            var cpuConfig = new CpuConfig { CpuTotal = false, CpuPackage = false, CpuTemp = false, CpuClock = true };
           
            var cpuMeter = new CpuMeter("qwe", cpuConfig);

            Assert.AreEqual(1, cpuMeter.Units.Count);
            Assert.IsInstanceOfType(cpuMeter.Units.First(), typeof(FreqUnit));
        }

        [TestMethod]
        public void UpdateMeters_NoMeters_ShoulSetMeterTextToNull()
        {
            var cpuConfig = new CpuConfig { CpuTotal = false, CpuPackage = false, CpuTemp = false, CpuClock = false };
           
            var cpuMeter = new CpuMeter("rty", cpuConfig);
            cpuMeter.UpdateMeters(new Mock<IHardware>().Object);

            Assert.IsNull(cpuMeter.Text);
        }
    }
}
