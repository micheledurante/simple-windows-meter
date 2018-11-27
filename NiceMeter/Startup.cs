using System;
using System.Windows;
using OpenHardwareMonitor.Hardware;
using System.Windows.Threading;
using NiceMeter.Models;
using NiceMeter.ViewModels;
using NiceMeter.EventHandlers;
using log4net;
using NiceMeter.Meter;

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
            log.Info("application started");

            // Init device. Mainboard and CPUs only
            var Computers = new Computers();
            var Computer = Computers.GetWorkingHardware();
            Computer.Open();

            var ComputerVisitor = new ComputerVisitor();
            Computer.Traverse(ComputerVisitor);

            var ObservableMeters = new ObservableMeters(ComputerVisitor.GetDisplayMeters());

            // Done with init view models, starting with init events
            var HardwareUpdate = new HardwareUpdate();
            // DispatcherTimer setup
            var Dispatcher = new DispatcherTimer();
            // Closure to pass additional values to the update method when the event is raised
            Dispatcher.Tick += (s, args) => HardwareUpdate.Update(Computer, ComputerVisitor);
            Dispatcher.Interval = new TimeSpan(0, 0, 1);

            // Done with timed events
            NiceMeterWindow niceMeterWindow = new NiceMeterWindow(ObservableMeters);

            // Window is ready. Start
            Dispatcher.Start();
            niceMeterWindow.Show();
        }
    }
}
