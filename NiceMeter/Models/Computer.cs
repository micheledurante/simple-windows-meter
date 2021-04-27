namespace NiceMeter.Models
{
    /// <summary>
    /// Wrap hardwaremonitor's computer class to implement our IComputer interface to add missing methods from the base class
    /// </summary>
    public class Computer : OpenHardwareMonitor.Hardware.Computer, IComputer
    {
    }
}
