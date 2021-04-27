namespace NiceMeter.Models
{
    /// <summary>
    /// Wrap hardwaremonitor's IComputer to add missing methods not covered in the base interface
    /// </summary>
    public interface IComputer : OpenHardwareMonitor.Hardware.IComputer
    {
        void Open();

        void Reset();

        void Close();
    }
}
