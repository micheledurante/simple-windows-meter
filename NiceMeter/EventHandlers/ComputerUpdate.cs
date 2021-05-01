using NiceMeter.Models;
using NiceMeter.Visitors;

namespace NiceMeter.EventHandlers
{
    /// <summary>
    /// Handle updates to the given computer's hardware
    /// </summary>
    public class ComputerUpdate : IComputerUpdate
    {
        /// <inheritdoc/>
        public void UpdateComputerHardware(IComputer computer)
        {
            computer.GetMainboardHardware()?.Update();
            computer.GetCpuHardware()?.Update();
            computer.GetGpuHardware()?.Update();
            computer.GetHddHardware()?.Update();
            computer.GetRamHardware()?.Update();
        }

        /// <inheritdoc/>
        public void UpdateMeters(IComputer computer, IHardwareVisitor hardwareVisitor)
        {
            hardwareVisitor.UpdateMainboard(computer.GetMainboardHardware());
            hardwareVisitor.UpdateCpu(computer.GetCpuHardware());
            hardwareVisitor.UpdateGpu(computer.GetGpuHardware());
            hardwareVisitor.UpdateHdd(computer.GetHddHardware());
            hardwareVisitor.UpdateRam(computer.GetRamHardware());
        }

        /// <inheritdoc/>
        public void Update(IComputer computer, IHardwareVisitor hardwareVisitor)
        {
            UpdateComputerHardware(computer);
            UpdateMeters(computer, hardwareVisitor);
        }
    }
}
