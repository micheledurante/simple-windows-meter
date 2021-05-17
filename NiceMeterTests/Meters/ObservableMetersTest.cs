using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Meters;
using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Gpu;
using NiceMeter.Meters.Hdd;
using NiceMeter.Meters.Mainboard;
using NiceMeter.Meters.Ram;
using NiceMeter.Models;
using OpenHardwareMonitor.Hardware;
using System.Collections.ObjectModel;
using System.Linq;

namespace NiceMeterTests.Meters
{
    [TestClass]
    public class ObservableMetersTest
    {
        [TestMethod]
        public void GetMeters_SingleMeter_ShouldReturnTheCollectionOfMeters()
        {
            var meterMock = new Mock<IMeter>();
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(new Mock<HardwareConfig>().Object, meters);

            Assert.AreEqual(1, observableMeters.GetMeters().Count);
            Assert.AreEqual(meterMock.Object, observableMeters.GetMeters().First());
        }

        [TestMethod]
        public void GetMeters_MultipleMeters_ShouldReturnTheCollectionOfMeters()
        {
            var meterMock1 = new Mock<IMeter>();
            var meterMock2 = new Mock<IMeter>();
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock1.Object);
            meters.Add(meterMock2.Object);

            var observableMeters = new ObservableMeters(new Mock<HardwareConfig>().Object, meters);

            Assert.AreEqual(2, observableMeters.GetMeters().Count);
            Assert.AreEqual(meterMock1.Object, observableMeters.GetMeters()[0]);
            Assert.AreEqual(meterMock2.Object, observableMeters.GetMeters()[1]);
        }

        [TestMethod]
        public void GetMainboardMeter_MainboardNotEnabled_ShouldReturnNull()
        {
            var meterMock = new Mock<IMeter>();
            var hardwareConfig = new HardwareConfig { MainboardEnabled = false };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetMainboardMeter();

            Assert.IsNull(meter);
        }

        [TestMethod]
        public void GetHardwareConfig_Default_ShouldReturnTheStoredHardwareConfig()
        {
            var hardwareConfigMock = new Mock<HardwareConfig>();
            var metersMock = new Mock<ObservableCollection<IMeter>>();

            var observableMeters = new ObservableMeters(hardwareConfigMock.Object, metersMock.Object);
            var hardwareConfig = observableMeters.GetHardwareConfig();

            Assert.AreEqual(hardwareConfigMock.Object, hardwareConfig);
        }

        // Mainboard meters

        [TestMethod]
        public void GetMainboardMeter_MainboardEnabledMainboardMeterNotFound_ShouldReturnNull()
        {
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.CPU);
            var hardwareConfig = new HardwareConfig { MainboardEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetMainboardMeter();

            Assert.IsNull(meter);
            meterMock.Verify(x => x.GetHardwareType(), Times.Once);
        }

        [TestMethod]
        public void GetMainboardMeter_MainboardEnabledMainboardMeterFound_ShouldReturnTheMainboardMeter()
        {
            var mainboardMeter = new MainboardMeter(new Faker().Random.Word(), new Mock<MainboardConfig>().Object); // Can only work with concrete types due to linq OfType()
            var hardwareConfig = new HardwareConfig { MainboardEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(mainboardMeter);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetMainboardMeter();

            Assert.AreEqual(mainboardMeter, meter);
        }

        // CPU meters

        [TestMethod]
        public void GetCpuMeter_CpuNotEnabled_ShouldReturnNull()
        {
            var meterMock = new Mock<IMeter>();
            var hardwareConfig = new HardwareConfig { CPUEnabled = false };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetCpuMeter();

            Assert.IsNull(meter);
        }

        [TestMethod]
        public void GetCpuMeter_CpuEnabledCpuMeterNotFound_ShouldReturnNull()
        {
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.HDD);
            var hardwareConfig = new HardwareConfig { CPUEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetCpuMeter();

            Assert.IsNull(meter);
            meterMock.Verify(x => x.GetHardwareType(), Times.Once);
        }

        [TestMethod]
        public void GetCpuMeter_CpuEnabledCpuMeterFound_ShouldReturnTheCpuMeter()
        {
            var cpuMeter = new CpuMeter(new Faker().Random.Word(), new Mock<CpuConfig>().Object); // Can only work with concrete types due to linq OfType()
            var hardwareConfig = new HardwareConfig { CPUEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(cpuMeter);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetCpuMeter();

            Assert.AreEqual(cpuMeter, meter);
        }

        // RAM meters

        [TestMethod]
        public void GetRamMeter_RamNotEnabled_ShouldReturnNull()
        {
            var meterMock = new Mock<IMeter>();
            var hardwareConfig = new HardwareConfig { RAMEnabled = false };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetRamMeter();

            Assert.IsNull(meter);
        }

        [TestMethod]
        public void GetRamMeter_RamEnabledRamMeterNotFound_ShouldReturnNull()
        {
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.HDD);
            var hardwareConfig = new HardwareConfig { RAMEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetRamMeter();

            Assert.IsNull(meter);
            meterMock.Verify(x => x.GetHardwareType(), Times.Once);
        }

        [TestMethod]
        public void GetRamMeter_RamEnabledRamMeterFound_ShouldReturnTheRamMeter()
        {
            var ramMeter = new RamMeter(); // Can only work with concrete types due to linq OfType()
            var hardwareConfig = new HardwareConfig { RAMEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(ramMeter);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetRamMeter();

            Assert.AreEqual(ramMeter, meter);
        }

        // HDD meters

        [TestMethod]
        public void GetHddMeter_HddNotEnabled_ShouldReturnNull()
        {
            var meterMock = new Mock<IMeter>();
            var hardwareConfig = new HardwareConfig { HDDEnabled = false };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetHddMeter();

            Assert.IsNull(meter);
        }

        [TestMethod]
        public void GetHddMeter_HddEnabledHddMeterNotFound_ShouldReturnNull()
        {
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.Mainboard);
            var hardwareConfig = new HardwareConfig { HDDEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetHddMeter();

            Assert.IsNull(meter);
            meterMock.Verify(x => x.GetHardwareType(), Times.Once);
        }

        [TestMethod]
        public void GetHddMeter_HddEnabledHddMeterFound_ShouldReturnTheHddMeter()
        {
            var ramMeter = new HddMeter(); // Can only work with concrete types due to linq OfType()
            var hardwareConfig = new HardwareConfig { HDDEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(ramMeter);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetHddMeter();

            Assert.AreEqual(ramMeter, meter);
        }

        // GPU meters

        [TestMethod]
        public void GetGpuMeter_GpuNotEnabled_ShouldReturnNull()
        {
            var meterMock = new Mock<IMeter>();
            var hardwareConfig = new HardwareConfig { GPUEnabled = false };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetGpuMeter();

            Assert.IsNull(meter);
        }

        [TestMethod]
        public void GetGpuMeter_GpuEnabledGpuMeterNotFound_ShouldReturnNull()
        {
            var meterMock = new Mock<IMeter>();
            meterMock.Setup(x => x.GetHardwareType()).Returns(HardwareType.HDD);
            var hardwareConfig = new HardwareConfig { GPUEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(meterMock.Object);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetGpuMeter();

            Assert.IsNull(meter);
            meterMock.Verify(x => x.GetHardwareType(), Times.Exactly(2));
        }

        [TestMethod]
        public void GetGpuMeter_GpuEnabledAtiGpuMeterFound_ShouldReturnTheGpuMeter()
        {
            var atiGpuMeter = new GpuMeter(new Faker().Random.Word(), HardwareType.GpuAti, new Mock<GpuConfig>().Object); // Can only work with concrete types due to linq OfType()
            var hardwareConfig = new HardwareConfig { GPUEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(atiGpuMeter);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetGpuMeter();

            Assert.AreEqual(atiGpuMeter, meter);
        }

        [TestMethod]
        public void GetGpuMeter_GpuEnabledNvidiaGpuMeterFound_ShouldReturnTheGpuMeter()
        {
            var nvidiaGpuMeter = new GpuMeter(new Faker().Random.Word(), HardwareType.GpuNvidia, new Mock<GpuConfig>().Object); // Can only work with concrete types due to linq OfType()
            var hardwareConfig = new HardwareConfig { GPUEnabled = true };
            var meters = new ObservableCollection<IMeter>();
            meters.Add(nvidiaGpuMeter);

            var observableMeters = new ObservableMeters(hardwareConfig, meters);
            var meter = observableMeters.GetGpuMeter();

            Assert.AreEqual(nvidiaGpuMeter, meter);
        }
    }
}
