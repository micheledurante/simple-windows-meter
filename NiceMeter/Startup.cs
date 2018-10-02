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
using log4net;

namespace NiceMeter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class Startup : Application
    {
        /// <summary>
        /// Logger instance
        /// </summary>
        internal static readonly ILog log = LogManager.GetLogger(typeof(Startup));

        /// <summary>
        /// Startup event of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Init logger
            log4net.Config.XmlConfigurator.Configure();
            log.Info("application started.");

            // Init device. Mainboard and CPUs only
            var Computers = new Computers();
            var Computer = Computers.GetTesting();
            Computer.Open();
            log.Debug(Computer);

            // possibly other init checks on computer etc.. here

            // Init collection
            var InitObservableCollection = new ObservableCollection<IMeter>
            {
                new MainboardMeter().FormatText(Computer.Hardware[0]),
                new CpuMeter().FormatText(Computer.Hardware[1]).FormatValues(Computer.Hardware[1].Sensors)
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
