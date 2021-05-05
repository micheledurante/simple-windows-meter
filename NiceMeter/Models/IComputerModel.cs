using OpenHardwareMonitor.Hardware;

namespace NiceMeter.Models
{
    /// <summary>
    /// Wrap OpenHardwareMonitor's IComputer to add missing methods not covered in the base interface
    /// </summary>
    public interface IComputerModel : IComputer
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
        /// Update the enabled hardware in order to start all sensors
        /// </summary>
        void Update();

        /// <summary>
        /// Return the cached hardware for the given hardware type
        /// </summary>
        /// <param name="hardwareType"></param>
        /// <returns></returns>
        IHardware FindHardware(HardwareType hardwareType);

        /// <summary>
        /// Return the cached sub hardware for the given hardware type
        /// </summary>
        /// <param name="hardwareType"></param>
        /// <returns></returns>
        IHardware FindSubHardware(HardwareType hardwareType);

        /// <summary>
        /// Return the current computer's Mainboard hardware
        /// </summary>
        /// <returns></returns>
        IHardware GetMainboardHardware();

        /// <summary>
        /// Return the current computer's Mainboard Sub hardware
        /// </summary>
        /// <returns></returns>
        IHardware GetMainboardSubHardware();

        /// <summary>
        /// Return the current computer's CPU hardware
        /// </summary>
        /// <returns></returns>
        IHardware GetCpuHardware();

        /// <summary>
        /// Return the current computer's GPU hardware
        /// </summary>
        /// <returns></returns>
        IHardware GetGpuHardware();

        /// <summary>
        /// Return the current computer's HDD hardware
        /// </summary>
        /// <returns></returns>
        IHardware GetHddHardware();

        /// <summary>
        /// Return the current computer's RAM hardware
        /// </summary>
        /// <returns></returns>
        IHardware GetRamHardware();
    }
}
