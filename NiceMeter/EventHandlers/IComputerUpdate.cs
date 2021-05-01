using NiceMeter.Models;
using NiceMeter.ViewModels;

namespace NiceMeter.EventHandlers
{
    interface IComputerUpdate
    {
        /// <summary>
        /// Update the hardware of the given computer and the values in the visitor
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="computerVisitor"></param>
        void Update(IComputer computer, IVisitorObservable computerVisitor);
    }
}
