using System;
using System.Windows;
using System.Windows.Threading;
using NiceMeter.Models;
using NiceMeter.ViewModels;
using NiceMeter.EventHandlers;
using log4net;
using NiceMeter.Meter;
using OpenHardwareMonitor.Hardware;
using NiceMeter.Interfaces;

namespace NiceMeter
{
    public partial class Startup : Application
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Startup));

        /// <summary>
        /// Return the computer with the devices to observe
        /// </summary>
        /// <returns></returns>
        public Computer GetComputer()
        {
            var computers = new Computers();
            return computers.GetAllHardware();
        }

        /// <summary>
        /// Visit the required devices and create the set of meters to observe
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="computerVisitor"></param>
        /// <returns></returns>
        public IObservableMeters StartObservableMeters(Computer computer, ComputerVisitor computerVisitor)
        {
            IObservableMeters observableMeters = null;

            try
            {
                computer.Open();
                computer.Traverse(computerVisitor);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                Environment.Exit(909);
            }

            try
            {
                observableMeters = new ObservableMeters(computerVisitor.GetDisplayMeters());
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                Environment.Exit(909);
            }

            return observableMeters;
        }

        /// <summary>
        /// Startup event of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void Application_Startup(object sender, StartupEventArgs ev)
        {
            // Init logger
            log4net.Config.XmlConfigurator.Configure();
            logger.Info("NiceMeter application started");

            // Init devices
            var computer = GetComputer();
            var computerVisitor = new ComputerVisitor();

            var observableMeters = StartObservableMeters(computer, computerVisitor);

            // Done with init view models, starting with init events
            var hardwareUpdate = new HardwareUpdate();
            // DispatcherTimer setup
            var dispatcher = new DispatcherTimer();
            // Closure to pass additional values to the update method when the event is raised
            dispatcher.Tick += (s, args) => hardwareUpdate.Update(computer, computerVisitor);
            dispatcher.Interval = new TimeSpan(0, 0, 1);

            // NiceMeter window
            NiceMeterWindow niceMeterWindow = new NiceMeterWindow(observableMeters, SystemParameters.WorkArea.Right);
            niceMeterWindow.CreateView();

            try
            {
                dispatcher.Start();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            niceMeterWindow.Show();
        }
    }
}
