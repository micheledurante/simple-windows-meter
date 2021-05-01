using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Models;
using NiceMeter.EventHandlers;

namespace NiceMeterTests.EventHandlers
{
    [TestClass]
    public class ComputerUpdateTest
    {
        [TestMethod]
        public void UpdateComputerHardware_NonNullHardwares_ShouldCallUpdateOnEachHardware()
        {
            var mainboardHardwareMock = new Mock<OpenHardwareMonitor.Hardware.IHardware>();
            mainboardHardwareMock.Setup(x => x.Update());
            var cpuHardwareMock = new Mock<OpenHardwareMonitor.Hardware.IHardware>();
            cpuHardwareMock.Setup(x => x.Update());
            var gpuHardwareMock = new Mock<OpenHardwareMonitor.Hardware.IHardware>();
            gpuHardwareMock.Setup(x => x.Update());
            var hddHardwareMock = new Mock<OpenHardwareMonitor.Hardware.IHardware>();
            hddHardwareMock.Setup(x => x.Update());
            var ramHardwareMock = new Mock<OpenHardwareMonitor.Hardware.IHardware>();
            ramHardwareMock.Setup(x => x.Update());

            var computer = new Mock<IComputer>();
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
            var computer = new Mock<IComputer>();
            computer.Setup(x => x.GetMainboardHardware()).Returns((OpenHardwareMonitor.Hardware.IHardware)null);
            computer.Setup(x => x.GetCpuHardware()).Returns((OpenHardwareMonitor.Hardware.IHardware)null);
            computer.Setup(x => x.GetGpuHardware()).Returns((OpenHardwareMonitor.Hardware.IHardware)null);
            computer.Setup(x => x.GetHddHardware()).Returns((OpenHardwareMonitor.Hardware.IHardware)null);
            computer.Setup(x => x.GetRamHardware()).Returns((OpenHardwareMonitor.Hardware.IHardware)null);

            var computerUpdate = new ComputerUpdate();
            computerUpdate.UpdateComputerHardware(computer.Object);

            computer.Verify(x => x.GetMainboardHardware(), Times.Once);
            computer.Verify(x => x.GetCpuHardware(), Times.Once);
            computer.Verify(x => x.GetGpuHardware(), Times.Once);
            computer.Verify(x => x.GetHddHardware(), Times.Once);
            computer.Verify(x => x.GetRamHardware(), Times.Once);
        }
    }
}
