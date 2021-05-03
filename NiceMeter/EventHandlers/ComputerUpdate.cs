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
        public void UpdateComputerHardware(IComputerModel computer)
        {
            computer.GetMainboardHardware()?.Update();
            computer.GetCpuHardware()?.Update();
            computer.GetGpuHardware()?.Update();
            computer.GetHddHardware()?.Update();
            computer.GetRamHardware()?.Update();
        }

        /// <inheritdoc/>
        public void UpdateMeters(IComputerModel computer, IHardwareVisitor hardwareVisitor)
        {
            hardwareVisitor.UpdateMainboard(computer.GetMainboardHardware());
            hardwareVisitor.UpdateCpu(computer.GetCpuHardware());
            hardwareVisitor.UpdateGpu(computer.GetGpuHardware());
            hardwareVisitor.UpdateHdd(computer.GetHddHardware());
            hardwareVisitor.UpdateRam(computer.GetRamHardware());
        }

        /// <inheritdoc/>
        public void Update(IComputerModel computer, IHardwareVisitor hardwareVisitor)
        {
            UpdateComputerHardware(computer);
            UpdateMeters(computer, hardwareVisitor);
        }
    }
}
