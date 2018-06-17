using System;
using System.Windows;
using OpenHardwareMonitor.Hardware;
using System.Linq;
using System.Windows.Threading;

namespace NiceMeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Defines the computer to measure
        /// </summary>
        private Computer Computer = new Computer
        {
            MainboardEnabled = true,
            CPUEnabled = true,
            RAMEnabled = true,
            GPUEnabled = true,
            FanControllerEnabled = true,
            HDDEnabled = true
        };

        /// <summary> 
        /// Event function that returns the current values of the sensors 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void Tick(object sender, EventArgs e)
        {
            // Gets a list of enabled hardware strings 
            var HardwareList = Computer.Hardware.Select(x => x.HardwareType).ToList();

            foreach (var Hardware in Computer.Hardware)
            {
                Hardware.Update();

                foreach (var Sensor in Hardware.Sensors)
                {
                    if (Sensor.Value.HasValue)
                        Console.WriteLine(String.Format("{0} - {1} - {2} = {3}", Hardware.HardwareType, Sensor.Name, Sensor.SensorType, Sensor.Value));
                }
            }
        }

        public MainWindow()
        {   
            //  DispatcherTimer setup
            var Dispatcher = new DispatcherTimer();
            Dispatcher.Tick += new EventHandler(Tick);
            Dispatcher.Interval = new TimeSpan(0, 0, 1);

            // Start measuring
            Computer.Open();

            // Start timed event. Bind data to the UI in the correct thread.
            Dispatcher.Start();

            // Init window
            InitializeComponent();
        }
    }
}
