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
        void UpdateComputerHardware(IComputerModel computer);

        /// <summary>
        /// Update values in the visitor's meters for the given computer
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="hardwareVisitor"></param>
        void UpdateMeters(IComputerModel computer, IHardwareVisitor hardwareVisitor);

        /// <summary>
        /// Update the hardware of the given computer and the values in the visitor
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="hardwareVisitor"></param>
        void Update(IComputerModel computer, IHardwareVisitor hardwareVisitor);
    }
}
