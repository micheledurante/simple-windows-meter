using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Models;
using NiceMeter.EventHandlers;
using NiceMeter.Visitors;
using OpenHardwareMonitor.Hardware;

namespace NiceMeterTests.EventHandlers
{
    [TestClass]
    public class ComputerUpdateTest
    {
        [TestMethod]
        public void UpdateComputerHardware_NonNullHardwares_ShouldCallUpdateOnEachHardware()
        {
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.Update());
            var cpuHardwareMock = new Mock<IHardware>();
            cpuHardwareMock.Setup(x => x.Update());
            var gpuHardwareMock = new Mock<IHardware>();
            gpuHardwareMock.Setup(x => x.Update());
            var hddHardwareMock = new Mock<IHardware>();
            hddHardwareMock.Setup(x => x.Update());
            var ramHardwareMock = new Mock<IHardware>();
            ramHardwareMock.Setup(x => x.Update());

            var computer = new Mock<IComputerModel>();
            computer.Setup(x => x.GetMainboardHardware()).Returns(mainboardHardwareMock.Object);
            computer.Setup(x => x.GetCpuHardware()).Returns(cpuHardwareMock.Object);
            computer.Setup(x => x.GetGpuHardware()).Returns(gpuHardwareMock.Object);
            computer.Setup(x => x.GetHddHardware()).Returns(hddHardwareMock.Object);
            computer.Setup(x => x.GetRamHardware()).Returns(ramHardwareMock.Object);

            var computerUpdate = new ComputerUpdate();
            computerUpdate.UpdateComputerHardware(computer.Object);

            computer.Verify(x => x.GetMainboardHardware(), Times.Once);
            computer.Verify(x => x.GetCpuHardware(), Times.Once);
            computer.Verify(x => x.GetGpuHardware(), Times.Once);
            computer.Verify(x => x.GetHddHardware(), Times.Once);
            computer.Verify(x => x.GetRamHardware(), Times.Once);
            mainboardHardwareMock.Verify(x => x.Update(), Times.Once);
            cpuHardwareMock.Verify(x => x.Update(), Times.Once);
            gpuHardwareMock.Verify(x => x.Update(), Times.Once);
            hddHardwareMock.Verify(x => x.Update(), Times.Once);
            ramHardwareMock.Verify(x => x.Update(), Times.Once);
        }

        [TestMethod]
        public void UpdateComputerHardware_NullHardwares_ShouldNotCallUpdate()
        {
            var computer = new Mock<IComputerModel>();
            computer.Setup(x => x.GetMainboardHardware()).Returns((IHardware)null);
            computer.Setup(x => x.GetCpuHardware()).Returns((IHardware)null);
            computer.Setup(x => x.GetGpuHardware()).Returns((IHardware)null);
            computer.Setup(x => x.GetHddHardware()).Returns((IHardware)null);
            computer.Setup(x => x.GetRamHardware()).Returns((IHardware)null);

            var computerUpdate = new ComputerUpdate();
            computerUpdate.UpdateComputerHardware(computer.Object);

            computer.Verify(x => x.GetMainboardHardware(), Times.Once);
            computer.Verify(x => x.GetCpuHardware(), Times.Once);
            computer.Verify(x => x.GetGpuHardware(), Times.Once);
            computer.Verify(x => x.GetHddHardware(), Times.Once);
            computer.Verify(x => x.GetRamHardware(), Times.Once);
        }

        [TestMethod]
        public void UpdateVistorMeters_NullHardwares_ShouldCallUpdate()
        {
            var computer = new Mock<IComputerModel>();
            computer.Setup(x => x.GetMainboardHardware()).Returns((IHardware)null);
            computer.Setup(x => x.GetCpuHardware()).Returns((IHardware)null);
            computer.Setup(x => x.GetGpuHardware()).Returns((IHardware)null);
            computer.Setup(x => x.GetHddHardware()).Returns((IHardware)null);
            computer.Setup(x => x.GetRamHardware()).Returns((IHardware)null);

            var hardwareVisitor = new Mock<IHardwareVisitor>();
            hardwareVisitor.Setup(x => x.UpdateMainboard(null));
            hardwareVisitor.Setup(x => x.UpdateCpu(null));
            hardwareVisitor.Setup(x => x.UpdateGpu(null));
            hardwareVisitor.Setup(x => x.UpdateHdd(null));
            hardwareVisitor.Setup(x => x.UpdateRam(null));

            var computerUpdate = new ComputerUpdate();
            computerUpdate.UpdateMeters(computer.Object, hardwareVisitor.Object);

            computer.Verify(x => x.GetMainboardHardware(), Times.Once);
            computer.Verify(x => x.GetCpuHardware(), Times.Once);
            computer.Verify(x => x.GetGpuHardware(), Times.Once);
            computer.Verify(x => x.GetHddHardware(), Times.Once);
            computer.Verify(x => x.GetRamHardware(), Times.Once);

            hardwareVisitor.Verify(x => x.UpdateMainboard(null), Times.Once);
            hardwareVisitor.Verify(x => x.UpdateCpu(null), Times.Once);
            hardwareVisitor.Verify(x => x.UpdateGpu(null), Times.Once);
            hardwareVisitor.Verify(x => x.UpdateHdd(null), Times.Once);
            hardwareVisitor.Verify(x => x.UpdateRam(null), Times.Once);
        }

        [TestMethod]
        public void UpdateVistorMeters_NonNullHardwares_ShouldCallUpdate()
        {
            var mainboardHardwareMock = new Mock<IHardware>();
            mainboardHardwareMock.Setup(x => x.Update());
            var cpuHardwareMock = new Mock<IHardware>();
            cpuHardwareMock.Setup(x => x.Update());
            var gpuHardwareMock = new Mock<IHardware>();
            gpuHardwareMock.Setup(x => x.Update());
            var hddHardwareMock = new Mock<IHardware>();
            hddHardwareMock.Setup(x => x.Update());
            var ramHardwareMock = new Mock<IHardware>();
            ramHardwareMock.Setup(x => x.Update());

            var computer = new Mock<IComputerModel>();
            computer.Setup(x => x.GetMainboardHardware()).Returns(mainboardHardwareMock.Object);
            computer.Setup(x => x.GetCpuHardware()).Returns(cpuHardwareMock.Object);
            computer.Setup(x => x.GetGpuHardware()).Returns(gpuHardwareMock.Object);
            computer.Setup(x => x.GetHddHardware()).Returns(hddHardwareMock.Object);
            computer.Setup(x => x.GetRamHardware()).Returns(ramHardwareMock.Object);

            var hardwareVisitor = new Mock<IHardwareVisitor>();
            hardwareVisitor.Setup(x => x.UpdateMainboard(mainboardHardwareMock.Object));
            hardwareVisitor.Setup(x => x.UpdateCpu(cpuHardwareMock.Object));
            hardwareVisitor.Setup(x => x.UpdateGpu(gpuHardwareMock.Object));
            hardwareVisitor.Setup(x => x.UpdateHdd(hddHardwareMock.Object));
            hardwareVisitor.Setup(x => x.UpdateRam(ramHardwareMock.Object));

            var computerUpdate = new ComputerUpdate();
            computerUpdate.UpdateMeters(computer.Object, hardwareVisitor.Object);

            computer.Verify(x => x.GetMainboardHardware(), Times.Once);
            computer.Verify(x => x.GetCpuHardware(), Times.Once);
            computer.Verify(x => x.GetGpuHardware(), Times.Once);
            computer.Verify(x => x.GetHddHardware(), Times.Once);
            computer.Verify(x => x.GetRamHardware(), Times.Once);

            hardwareVisitor.Verify(x => x.UpdateMainboard(mainboardHardwareMock.Object), Times.Once);
            hardwareVisitor.Verify(x => x.UpdateCpu(cpuHardwareMock.Object), Times.Once);
            hardwareVisitor.Verify(x => x.UpdateGpu(gpuHardwareMock.Object), Times.Once);
            hardwareVisitor.Verify(x => x.UpdateHdd(hddHardwareMock.Object), Times.Once);
            hardwareVisitor.Verify(x => x.UpdateRam(ramHardwareMock.Object), Times.Once);
        }
    }
}
