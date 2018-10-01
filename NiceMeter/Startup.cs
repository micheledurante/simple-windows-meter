using System;
using System.Windows;
using OpenHardwareMonitor.Hardware;
using System.Windows.Threading;
using NiceMeter.Models;
using NiceMeter.ViewModels;
using System.Collections.ObjectModel;
using NiceMeter.EventHandlers;
using System.Collections.Generic;
using NiceMeter.Interfaces;

namespace NiceMeter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class Startup : Application
    {
        /// <summary>
        /// Startup event of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Init device. Mainboard and CPUs only
            var Computers = new Computers();
            var Computer = Computers.GetTesting();
            Computer.Open();

            // possibly other init checks on computer etc.. here

            // Init collection
            var InitObservableCollection = new ObservableCollection<IMeter>
            {
                new MainboardMeter(Computer.Hardware[0].Name).FormatText(Computer.Hardware[0].Sensors),
                new CpuMeter(Computer.Hardware[1].Name, 4).FormatText(Computer.Hardware[1].Sensors)
            };

            var Meters = new ObservableMeters(InitObservableCollection);

            // Done with init view models
            var x = new HardwareUpdate();
            // DispatcherTimer setup
            var Dispatcher = new DispatcherTimer();
            // Closure to pass additional values to the update method when the event is raised
            Dispatcher.Tick += (s, args) => x.Update(Computer, Meters);
            Dispatcher.Interval = new TimeSpan(0, 0, 1);

            // Done with timed events
            NiceMeterWindow niceMeterWindow = new NiceMeterWindow(Meters);

            // Window is ready. Start
            Dispatcher.Start();
            niceMeterWindow.Show();
        }
    }
}
