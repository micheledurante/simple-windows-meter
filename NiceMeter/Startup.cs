using System;
using System.Windows;
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
        /// <param name="ev"></param>
        private void Application_Startup(object sender, StartupEventArgs ev)
        {
            // Init logger
            log4net.Config.XmlConfigurator.Configure();
            log.Info("application started");

            // Init devices
            var computers = new Computers();
            var computer = computers.GetAllHardware();
            var computerVisitor = new ComputerVisitor();

            try
            {
                computer.Open();
                computer.Traverse(computerVisitor);
            } 
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            ObservableMeters observableMeters = null;

            try
            {
                observableMeters = new ObservableMeters(computerVisitor.GetDisplayMeters());
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            // Done with init view models, starting with init events
            var hardwareUpdate = new HardwareUpdate();
            // DispatcherTimer setup
            var dispatcher = new DispatcherTimer();
            // Closure to pass additional values to the update method when the event is raised
            dispatcher.Tick += (s, args) => hardwareUpdate.Update(computer, computerVisitor);
            dispatcher.Interval = new TimeSpan(0, 0, 1);

            // Main window
            NiceMeterWindow niceMeterWindow = new NiceMeterWindow(observableMeters);

            try
            {
                dispatcher.Start();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            niceMeterWindow.Show();
        }
    }
}
