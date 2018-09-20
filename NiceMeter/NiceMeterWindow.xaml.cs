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
        /// The ViewModel for the ListView.
        /// </summary>
        private List<Meter> Meters;

        /// <summary> 
        /// Event function that returns the current values of the sensors 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void Tick(object sender, EventArgs e)
        {
            // CPU update
            Computer.Hardware[1].Update();

            for (int i = 0; i < Computer.Hardware[1].Sensors.Length; i++)
            {
                Meters[i].Value = string.Format("{0} {1}", Computer.Hardware[1].Sensors[i].SensorType, Computer.Hardware[1].Sensors[i].Value);
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
            Computer.Open();

            // Init window
            InitializeComponent();
            Dispatcher.Start();

            // Mobo init
            Meters = new List<Meter>
            {
                new Meter() { Name = Computer.Hardware[0].Name, Value = "", HardwareType = HardwareType.Mainboard }
            };

            // CPU init
            foreach (var Sensor in Computer.Hardware[1].Sensors)
            {
                Meters.Add(new Meter() { Name = Sensor.Name, Value = string.Format("{0} {1}", Sensor.SensorType, Sensor.Value), HardwareType = HardwareType.CPU });
            }

            StatMeters.ItemsSource = Meters;

            var view = (CollectionView)CollectionViewSource.GetDefaultView(StatMeters.ItemsSource);
            var groupDescription = new PropertyGroupDescription("HardwareType");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
