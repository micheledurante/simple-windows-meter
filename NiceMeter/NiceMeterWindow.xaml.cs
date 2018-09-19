using System;
using System.Windows;
using OpenHardwareMonitor.Hardware;
using System.Linq;
using System.Windows.Threading;
using NiceMeter.Models;
using System.Collections.Generic;
using System.Windows.Data;
using NiceMeter.ViewModels;

namespace NiceMeter
{
    /// <summary>
    /// Interaction logic for NiceMeterWindow.xaml
    /// </summary>
    public partial class NiceMeterWindow : Window
    {
        /// <summary>
        /// The device to use for measurements
        /// </summary>
        private Computer Computer;

        /// <summary>
        /// List of enabled types for this computer. Used as table headers(?)
        /// </summary>
        private List<HardwareType> HardwareList = new List<HardwareType>();

        /// <summary> 
        /// Event function that returns the current values of the sensors 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void Tick(object sender, EventArgs e)
        {
            foreach (var Hardware in Computer.Hardware)
            {
                Hardware.Update();

                foreach (var Sensor in Hardware.Sensors)
                {
                    if (Sensor.Value.HasValue)
                    {
                        Console.WriteLine(String.Format("{0} - {1} - {2} = {3}", Hardware.HardwareType, Sensor.Name, Sensor.SensorType, Sensor.Value));
                    }
                }
            }
        }

        /// <summary>
        /// Start the window
        /// </summary>
        public NiceMeterWindow()
        {
            // DispatcherTimer setup
            var Dispatcher = new DispatcherTimer();
            Dispatcher.Tick += new EventHandler(Tick);
            Dispatcher.Interval = new TimeSpan(0, 0, 1);

            // Init device. Mainboard and CPUs only
            var Devices = new DefaultDevices();
            Computer = Devices.GetSampleComputer();

            // Open the computer and start the timed event
            // The computer contains enabled types and a list of available hardware.
            // The tick function has to be called to update certain hardwares, e.g. not the mobo.
            // The Update() function in available for IHardware. There's also GetReport() that returns a string with all kinds of info. See what to do with that.(discard it for now?)
            Computer.Open();
            Dispatcher.Start();

            // Gets the list of enabled types. For headers (?)
            HardwareList = Computer.Hardware.Select(x => x.HardwareType).ToList();

            // Init window
            InitializeComponent();

            // Need to build a list of tables, with custom formatting.
            // Pass to the tick function the rows that need updating regularly.
            // Put ehre an entry point to the program that visualises the rows/tables.
            var sensors = new List<Meter>
            {
                new Meter() { Name = "ASUS", Value = 42, HardwareType = HardwareType.CPU },
                new Meter() { Name = "CPU 1", Value = 39, HardwareType = HardwareType.CPU },
                new Meter() { Name = "CPU 2", Value = 13, HardwareType = HardwareType.Heatmaster }
            };

            StatMeters.ItemsSource = sensors;

            var view = (CollectionView)CollectionViewSource.GetDefaultView(StatMeters.ItemsSource);
            var groupDescription = new PropertyGroupDescription("HardwareType");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
