namespace NiceMeter.Models
{
    /// <summary>
    /// Wrap OpenHardwareMonitor's IComputer to add missing methods not covered in the base interface
    /// </summary>
    public interface IComputer : OpenHardwareMonitor.Hardware.IComputer
    {
        /// <summary>
        /// Reimplement Open() method missing from OpenHardwareMonitor's IComputer
        /// </summary>
        void Open();

        /// <summary>
        /// Reimplement Reset() method missing from OpenHardwareMonitor's IComputer
        /// </summary>
        void Reset();

        /// <summary>
        /// Reimplement Close() method missing from OpenHardwareMonitor's IComputer
        /// </summary>
        void Close();

        /// <summary>
        /// Return the cached hardware for the given hardware type
        /// </summary>
        /// <param name="hardwareType"></param>
        /// <returns></returns>
        OpenHardwareMonitor.Hardware.IHardware FindHardware(OpenHardwareMonitor.Hardware.HardwareType hardwareType);

        /// <summary>
        /// Return the current computer's Mainboard hardware
        /// </summary>
        /// <returns></returns>
        OpenHardwareMonitor.Hardware.IHardware GetMainboardHardware();

        /// <summary>
        /// Return the current computer's CPU hardware
        /// </summary>
        /// <returns></returns>
        OpenHardwareMonitor.Hardware.IHardware GetCpuHardware();

        /// <summary>
        /// Return the current computer's GPU hardware
        /// </summary>
        /// <returns></returns>
        OpenHardwareMonitor.Hardware.IHardware GetGpuHardware();

        /// <summary>
        /// Return the current computer's HDD hardware
        /// </summary>
        /// <returns></returns>
        OpenHardwareMonitor.Hardware.IHardware GetHddHardware();

        /// <summary>
        /// Return the current computer's RAM hardware
        /// </summary>
        /// <returns></returns>
        OpenHardwareMonitor.Hardware.IHardware GetRamHardware();
    }
}
