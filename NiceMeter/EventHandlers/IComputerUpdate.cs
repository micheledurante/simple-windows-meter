using NiceMeter.Models;
using NiceMeter.Visitors;

namespace NiceMeter.EventHandlers
{
    interface IComputerUpdate
    {
        /// <summary>
        /// Update hardware's values based on enabled devices for the given computer
        /// </summary>
        /// <param name="computer"></param>
        void UpdateComputerHardware(IComputer computer);

        /// <summary>
        /// Update values in the visitor's meters for the given computer
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="hardwareVisitor"></param>
        void UpdateMeters(IComputer computer, IHardwareVisitor hardwareVisitor);

        /// <summary>
        /// Update the hardware of the given computer and the values in the visitor
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="hardwareVisitor"></param>
        void Update(IComputer computer, IHardwareVisitor hardwareVisitor);
    }
}
