using System;
using System.Windows;
using System.Windows.Threading;
using NiceMeter.Models;
using NiceMeter.ViewModels;
using NiceMeter.EventHandlers;
using log4net;
using NiceMeter.Meters;

namespace NiceMeter
{
    public partial class Startup : Application
    {
        public const int TimerHours = 0;
        public const int TimerMinutes = 0;
        public const int TimerSeconds = 1; // Update meters every 2 seconds
        private static readonly ILog logger = LogManager.GetLogger(typeof(Startup));
        private IComputer computer;

        /// <summary>
        /// Return the computer with the devices to observe
        /// </summary>
        /// <returns></returns>
        public Computer GetComputer(Computers computers)
        {
            return computers.GetAllHardware();
        }

        /// <summary>
        /// Visit the required devices and create the set of meters to observe
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="computerVisitor"></param>
        /// <returns></returns>
        public IObservableMeters CreateObservableMeters(IComputer computer, IVisitorObservable computerVisitor)
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
                //Environment.Exit(909);
            }

            try
            {
                observableMeters = new ObservableMeters(computerVisitor.ConvertMeters());
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                //Environment.Exit(909);
            }

            return observableMeters;
        }

        /// <summary>
        /// Create the timespan for the default interval
        /// </summary>
        /// <returns></returns>
        public TimeSpan CreateTimeSpan()
        {
            return new TimeSpan(TimerHours, TimerMinutes, TimerSeconds);
        }

        /// <summary>
        /// Create the timer for periodically visiting the computer's devices
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="computerVisitor"></param>
        /// <returns></returns>
        public DispatcherTimer CreateTimer(IComputer computer, IVisitorObservable computerVisitor, DispatcherTimer timer)
        {
            // Closure to pass additional values to the update method when the event is raised
            timer.Tick += (s, args) => new ComputerUpdate().Update(computer, computerVisitor);
            timer.Interval = CreateTimeSpan();
            return timer;
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

            // Init the computer and its devices
            computer = GetComputer(new Computers());
            var computerVisitor = new ComputerVisitor();

            try
            {
                // Init timer and events
                CreateTimer(computer, computerVisitor, new DispatcherTimer()).Start();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            // NiceMeter window
            var niceMeterWindow = new NiceMeterWindow(CreateObservableMeters(computer, computerVisitor), SystemParameters.WorkArea.Right);
            niceMeterWindow.CreateView();
            niceMeterWindow.Show();
        }

        /// <summary>
        /// Ensure that a shutdown of thew application correctly frees the computer resource
        /// </summary>
        /// <param name="exitCode"></param>
        public new void Shutdown(int exitCode)
        {
            computer.Close();
            
            base.Shutdown(exitCode);
        }
    }
}
