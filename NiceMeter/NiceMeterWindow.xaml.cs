using System;
using System.Windows;
using OpenHardwareMonitor.Hardware;
using System.Linq;
using System.Windows.Threading;
using NiceMeter.Models;
using System.Collections.Generic;
using System.Windows.Data;
using NiceMeter.ViewModels;
using System.Collections.ObjectModel;

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
        private ObservableMeters ObservableMeters;

        /// <summary> 
        /// Event function that returns the current values of the sensors 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void Tick(object sender, EventArgs e)
        {
            // CPU update
            Computer.Hardware[1].Update();

            // Collection update
            for (var i = 0; i < Computer.Hardware[1].Sensors.Length; i++)
            {
                for (var ii = 1; ii < ObservableMeters.GetMeters().Count -1; ii++)
                {
                    ObservableMeters.GetMeters()[ii].Text = string.Format("{0} {1}", Computer.Hardware[1].Sensors[i].SensorType, Computer.Hardware[1].Sensors[i].Value);
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
            Computer.Open();

            // Init window
            InitializeComponent();
            Dispatcher.Start();

            // Init collection
            // Mobo init
            var InitObservableCollection = new ObservableCollection<Meter>
            {
                new Meter() { Name = Computer.Hardware[0].Name, Text = "", HardwareType = HardwareType.Mainboard }
            };

            // CPU init
            foreach (var Sensor in Computer.Hardware[1].Sensors)
            {
                InitObservableCollection.Add(new Meter() { Name = Sensor.Name, Text = string.Format("{0} {1}", Sensor.SensorType, Sensor.Value), HardwareType = HardwareType.CPU });
            }

            ObservableMeters = new ObservableMeters(InitObservableCollection);

            StatMeters.ItemsSource = ObservableMeters.GetMeters();

            var view = (CollectionView)CollectionViewSource.GetDefaultView(StatMeters.ItemsSource);
            var groupDescription = new PropertyGroupDescription("HardwareType");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
