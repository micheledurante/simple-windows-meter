using System;
using System.Windows;
using OpenHardwareMonitor.Hardware;
using System.Linq;
using System.Windows.Threading;
using NiceMeter.Models;
using System.Collections.Generic;
using System.Windows.Data;

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
            Computer.Open();
            Dispatcher.Start();

            // Init window
            InitializeComponent();

            List<Sensor> items = new List<Sensor>();
            items.Add(new Sensor() { Name = "ASUS", Value = 42, HardwareType = HardwareType.CPU });
            items.Add(new Sensor() { Name = "CPU 1", Value = 39, HardwareType = HardwareType.CPU });
            items.Add(new Sensor() { Name = "CPU 2", Value = 13, HardwareType = HardwareType.Heatmaster });
            Sensors.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Sensors.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Comp");
            view.GroupDescriptions.Add(groupDescription);
        }

        public class Sensor
        {
            public string Name { get; set; }

            public int Value { get; set; }

            public string Mail { get; set; }

            public HardwareType HardwareType { get; set; }
        }
    }
}
