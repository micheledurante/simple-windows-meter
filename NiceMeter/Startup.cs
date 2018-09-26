using System;
using System.Windows;
using OpenHardwareMonitor.Hardware;
using System.Linq;
using System.Windows.Threading;
using NiceMeter.Models;
using System.Collections.Generic;
using NiceMeter.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace NiceMeter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class Startup : Application
    {
        private Computer Computer;
        private ObservableMeters Meters;

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
                for (var ii = 1; ii < Meters.GetMeters().Count - 1; ii++)
                {
                    Meters.GetMeters()[ii].Text = string.Format("{0} {1}", Computer.Hardware[1].Sensors[i].SensorType, Computer.Hardware[1].Sensors[i].Value);
                }
            }
        }

        /// <summary>
        /// Startup event of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // DispatcherTimer setup
            var Dispatcher = new DispatcherTimer();
            Dispatcher.Tick += new EventHandler(Tick);
            Dispatcher.Interval = new TimeSpan(0, 0, 1);

            // Init device. Mainboard and CPUs only
            var Computers = new Computers();
            Computer = Computers.GetTesting();
            Computer.Open();

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

            Meters = new ObservableMeters(InitObservableCollection);

            Dispatcher.Start();
            NiceMeterWindow niceMeterWindow = new NiceMeterWindow(Meters);
            niceMeterWindow.Show();
        }
    }
}
