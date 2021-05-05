using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Models;
using OpenHardwareMonitor.Hardware;
using System.Collections;
using System.Collections.Generic;

namespace NiceMeterTests.Models
{
    [TestClass]
    public class ComputerTest
    {
        [TestMethod]
        public void Computer_Constructor_TestComputerInheritanceAndProperties()
        {
            var computer = new ComputerModel();
            Assert.IsInstanceOfType(computer, typeof(Computer));
            Assert.IsInstanceOfType(computer, typeof(IComputerModel));
            Assert.AreEqual(0, computer.HardwareListCache.Count);
        }

        [TestMethod]
        public void FindHardware_NotFound_ShouldReturnNull()
        {
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.Mainboard);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(mainboardHardwareMock.Object);

            var mainboardHardware = computer.FindHardware(HardwareType.CPU);

            Assert.IsNull(mainboardHardware);
            mainboardHardwareMock.Verify(x => x.HardwareType, Times.Once);
        }

        [TestMethod]
        public void FindHardware_Found_ShouldReturnFoundHardware()
        {
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.Mainboard);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(mainboardHardwareMock.Object);

            var mainboardHardware = computer.FindHardware(HardwareType.Mainboard);

            Assert.AreEqual(mainboardHardwareMock.Object, mainboardHardware);
            mainboardHardwareMock.Verify(x => x.HardwareType, Times.Exactly(2));
        }

        [TestMethod]
        public void FindSubHardware_EmptySubHardwareList_ShouldReturnNull()
        {
            var emptySubHardware = new IHardware[0]; // Empty sub hardware is the default value, aka no sub hardware present
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.Mainboard);
            mainboardHardwareMock.Setup(x => x.SubHardware).Returns(emptySubHardware);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(mainboardHardwareMock.Object);

            var mainboardSubHardware = computer.FindSubHardware(HardwareType.Mainboard);

            Assert.IsNull(mainboardSubHardware);
            mainboardHardwareMock.Verify(x => x.HardwareType, Times.Once);
            mainboardHardwareMock.Verify(x => x.SubHardware, Times.Once);
        }

        [TestMethod]
        public void FindSubHardware_OneSubHardwarePresent_ShouldReturnSubHardware()
        {
            var subHardware = new Mock<IHardware>();
            subHardware.Setup(s => s.HardwareType).Returns(HardwareType.SuperIO);
            var singleSubHardware = new IHardware[1];
            singleSubHardware[0] = subHardware.Object; // We only deal with the first sub hardware
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.Mainboard);
            mainboardHardwareMock.Setup(x => x.SubHardware).Returns(singleSubHardware);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(mainboardHardwareMock.Object);

            var mainboardSubHardware = computer.FindSubHardware(HardwareType.Mainboard);

            Assert.AreEqual(mainboardHardwareMock.Object.SubHardware[0], mainboardSubHardware);
            mainboardHardwareMock.Verify(x => x.HardwareType, Times.Exactly(3));
            mainboardHardwareMock.Verify(x => x.SubHardware, Times.Exactly(4));

            subHardware.Verify(s => s.HardwareType, Times.Exactly(2));
        }

        [TestMethod]
        public void FindSubHardware_MultipleSubHardwaresPresent_ShouldReturnTheFirstSubHardwareOnly()
        {
            var subHardware1 = new Mock<IHardware>();
            var subHardware2 = new Mock<IHardware>();
            subHardware1.Setup(s => s.HardwareType).Returns(HardwareType.SuperIO);
            subHardware2.Setup(s => s.HardwareType).Returns(HardwareType.SuperIO);
            var multipleSubHardware = new IHardware[2];
            multipleSubHardware[0] = subHardware1.Object; // We only deal with the first sub hardware
            multipleSubHardware[1] = subHardware2.Object;
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.Mainboard);
            mainboardHardwareMock.Setup(x => x.SubHardware).Returns(multipleSubHardware);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(mainboardHardwareMock.Object);

            var mainboardSubHardware = computer.FindSubHardware(HardwareType.Mainboard);

            Assert.AreEqual(mainboardHardwareMock.Object.SubHardware[0], mainboardSubHardware);
            mainboardHardwareMock.Verify(x => x.HardwareType, Times.Exactly(3));
            mainboardHardwareMock.Verify(x => x.SubHardware, Times.Exactly(4));

            subHardware1.Verify(s => s.HardwareType, Times.Exactly(2));
            subHardware2.Verify(s => s.HardwareType, Times.Once);
        }

        // Mainboard hardware

        [TestMethod]
        public void GetMainboardHardware_MainboardIsDisabled_NoHardwareIsReturned()
        {
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.Mainboard);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(mainboardHardwareMock.Object);

            var mainboardHardware = computer.GetMainboardHardware();

            Assert.IsNull(mainboardHardware);
            mainboardHardwareMock.Verify(x => x.HardwareType, Times.Never);
        }

        [TestMethod]
        public void GetMainboardHardware_MainboardIsEnabled_MainbaordHardwareShouldBeReturned()
        {
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.Mainboard);

            var computer = new ComputerModel { MainboardEnabled = true};
            computer.HardwareListCache.Add(mainboardHardwareMock.Object);

            var mainboardHardware = computer.GetMainboardHardware();

            Assert.AreEqual(mainboardHardwareMock.Object, mainboardHardware);
            mainboardHardwareMock.Verify(x => x.HardwareType, Times.Exactly(2));
        }

        // CPU hardware

        [TestMethod]
        public void GetCpuHardware_CpuIsDisabled_NoHardwareIsReturned()
        {
            var cpuHardwareMock = new Mock<IHardware>();
            cpuHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.CPU);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(cpuHardwareMock.Object);

            var cpuHardware = computer.GetCpuHardware();

            Assert.IsNull(cpuHardware);
            cpuHardwareMock.Verify(x => x.HardwareType, Times.Never);
        }

        [TestMethod]
        public void GetCpuHardware_CpuIsEnabled_CpuHardwareShouldBeReturned()
        {
            var cpuHardwareMock = new Mock<IHardware>();
            cpuHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.CPU);

            var computer = new ComputerModel { CPUEnabled = true };
            computer.HardwareListCache.Add(cpuHardwareMock.Object);

            var cpuHardware = computer.GetCpuHardware();

            Assert.AreEqual(cpuHardwareMock.Object, cpuHardware);
            cpuHardwareMock.Verify(x => x.HardwareType, Times.Exactly(2));
        }

        // GPU ATI hardware

        [TestMethod]
        public void GetGpuHardware_GpuIsDisabled_NoGpuAtiHardwareIsReturned()
        {
            var gpuAtiHardwareMock = new Mock<IHardware>();
            gpuAtiHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.GpuAti);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(gpuAtiHardwareMock.Object);

            var gpuAtiHardware = computer.GetGpuHardware();

            Assert.IsNull(gpuAtiHardware);
            gpuAtiHardwareMock.Verify(x => x.HardwareType, Times.Never);
        }

        [TestMethod]
        public void GetGpuHardware_GpuIsEnabled_GpuAtiHardwareShouldBeReturned()
        {
            var gpuAtiHardwareMock = new Mock<IHardware>();
            gpuAtiHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.GpuAti);

            var computer = new ComputerModel { GPUEnabled = true };
            computer.HardwareListCache.Add(gpuAtiHardwareMock.Object);

            var gpuAtiHardware = computer.GetGpuHardware();

            Assert.AreEqual(gpuAtiHardwareMock.Object, gpuAtiHardware);
            gpuAtiHardwareMock.Verify(x => x.HardwareType, Times.Exactly(3));
        }

        // GPU Nvidia hardware

        [TestMethod]
        public void GetGpuHardware_GpuIsDisabled_NoGpuNvidiaHardwareIsReturned()
        {
            var gpuNvidiaHardwareMock = new Mock<IHardware>();
            gpuNvidiaHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.GpuNvidia);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(gpuNvidiaHardwareMock.Object);

            var gpuNvidiaHardware = computer.GetGpuHardware();

            Assert.IsNull(gpuNvidiaHardware);
            gpuNvidiaHardwareMock.Verify(x => x.HardwareType, Times.Never);
        }

        [TestMethod]
        public void GetGpuHardware_GpuIsEnbaled_GpuNvidiaHardwareShouldBeReturned()
        {
            var gpuNvidiaHardwareMock = new Mock<IHardware>();
            gpuNvidiaHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.GpuNvidia);

            var computer = new ComputerModel { GPUEnabled = true };
            computer.HardwareListCache.Add(gpuNvidiaHardwareMock.Object);

            var gpuNvidiaHardware = computer.GetGpuHardware();

            Assert.AreEqual(gpuNvidiaHardwareMock.Object, gpuNvidiaHardware);
            gpuNvidiaHardwareMock.Verify(x => x.HardwareType, Times.Exactly(3));
        }

        // HDD hardware

        [TestMethod]
        public void GetHddHardware_HddIsDisabled_NoHardwareIsReturned()
        {
            var hddHardwareMock = new Mock<IHardware>();
            hddHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.HDD);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(hddHardwareMock.Object);

            var hddHardware = computer.GetHddHardware();

            Assert.IsNull(hddHardware);
            hddHardwareMock.Verify(x => x.HardwareType, Times.Never);
        }

        [TestMethod]
        public void GetHddHardware_HddIsEnabled_HddHardwareShouldBeReturned()
        {
            var hddHardwareMock = new Mock<IHardware>();
            hddHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.HDD);

            var computer = new ComputerModel { HDDEnabled = true };
            computer.HardwareListCache.Add(hddHardwareMock.Object);

            var hddHardware = computer.GetHddHardware();

            Assert.AreEqual(hddHardwareMock.Object, hddHardware);
            hddHardwareMock.Verify(x => x.HardwareType, Times.Exactly(2));
        }

        // RAM hardware

        [TestMethod]
        public void GetRamHardware_RamIsDisabled_NoHardwareIsReturned()
        {
            var ramHardwareMock = new Mock<IHardware>();
            ramHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.RAM);

            var computer = new ComputerModel();
            computer.HardwareListCache.Add(ramHardwareMock.Object);

            var ramHardware = computer.GetRamHardware();

            Assert.IsNull(ramHardware);
            ramHardwareMock.Verify(x => x.HardwareType, Times.Never);
        }

        [TestMethod]
        public void GetRamHardware_RamIsEnabled_RamHardwareShouldBeReturned()
        {
            var ramHardwareMock = new Mock<IHardware>();
            ramHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.RAM);

            var computer = new ComputerModel { RAMEnabled = true };
            computer.HardwareListCache.Add(ramHardwareMock.Object);

            var ramHardware = computer.GetRamHardware();

            Assert.AreEqual(ramHardwareMock.Object, ramHardware);
            ramHardwareMock.Verify(x => x.HardwareType, Times.Exactly(2));
        }

        [TestMethod]
        public void Open_NoAddedHardware_ShouldUpdateComputerProperties()
        {
            var computer = new ComputerModel();
            computer.Open();

            Assert.IsTrue(computer.IsOpen);
            Assert.IsInstanceOfType(computer.HardwareListCache, typeof(List<IHardware>));
            Assert.AreEqual(0, computer.HardwareListCache.Count);
        }

        [TestMethod]
        public void Open_AddedHardware_ShouldUpdateComputerProperties()
        {
            var computer = new ComputerModel { MainboardEnabled = true};
            computer.Open();

            Assert.IsTrue(computer.IsOpen);
            Assert.IsInstanceOfType(computer.HardwareListCache, typeof(List<IHardware>));
            Assert.AreEqual(1, computer.HardwareListCache.Count);
        }

        [TestMethod]
        public void Update_NoAddedHardware_ShouldOpenComputerAndNotFailForNullHardware()
        {
            var computer = new ComputerModel();
            computer.Update();

            Assert.IsTrue(computer.IsOpen);
        }

        [TestMethod]
        public void Update_AddedHardwareAndEnabledHardware_ShouldOpenComputerAndUpdateHardware()
        {
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.Mainboard);
            mainboardHardwareMock.Setup(x => x.Update());

            var computer = new ComputerModel { MainboardEnabled = true};
            computer.HardwareListCache.Add(mainboardHardwareMock.Object);

            computer.Update();

            Assert.IsTrue(computer.IsOpen);
            mainboardHardwareMock.Verify(x => x.Update(), Times.Once);
        }

        [TestMethod]
        public void Update_AddedHardwareNonEnabledHardware_ShouldOpenComputerButNotUpdateHardware()
        {
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.HardwareType).Returns(HardwareType.Mainboard);
            mainboardHardwareMock.Setup(x => x.Update());

            var computer = new ComputerModel { CPUEnabled = true}; // Mainboard is not enabled in this case and Update() should be skipped
            computer.HardwareListCache.Add(mainboardHardwareMock.Object);

            computer.Update();

            Assert.IsTrue(computer.IsOpen);
            mainboardHardwareMock.Verify(x => x.Update(), Times.Never);
        }
    }
}
