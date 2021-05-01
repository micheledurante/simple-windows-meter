using NiceMeter.Models;
using NiceMeter.ViewModels;

namespace NiceMeter.EventHandlers
{
    /// <summary>
    /// Handle updates to the given computer's hardware
    /// </summary>
    public class ComputerUpdate : IComputerUpdate
    {
        /// <summary>
        /// Update hardware's values based on enabled devices for the given computer
        /// </summary>
        /// <param name="computer"></param>
        public void UpdateComputerHardware(IComputer computer)
        {
            computer.GetMainboardHardware()?.Update();
            computer.GetCpuHardware()?.Update();
            computer.GetGpuHardware()?.Update();
            computer.GetHddHardware()?.Update();
            computer.GetRamHardware()?.Update();
        }

        /// <summary>
        /// Update values in the visitor's meters for the given computer
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="computerVisitor"></param>
        public void UpdateVistorMeters(IComputer computer, IVisitorObservable computerVisitor)
        {
            computerVisitor.UpdateMainboard(computer.GetMainboardHardware());

            computerVisitor.UpdateCpu(computer.GetCpuHardware());
        }

        /// <inheritdoc/>
        public void Update(IComputer computer, IVisitorObservable computerVisitor)
        {
            UpdateComputerHardware(computer);

            UpdateVistorMeters(computer, computerVisitor);
        }
    }
}
