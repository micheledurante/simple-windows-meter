using System;
using System.Windows;
using System.Windows.Threading;
using NiceMeter.Models;
using NiceMeter.Visitors;
using NiceMeter.EventHandlers;
using log4net;
using NiceMeter.Meters;
using NiceMeter.Meters.Factories;

namespace NiceMeter
{
    public partial class Startup : Application
    {
        public const int TimerHours = 0; // Update meters every x hours
        public const int TimerMinutes = 0; // Update meters every x minutes
        public const int TimerSeconds = 2; // Update meters every x seconds
        private static readonly ILog logger = LogManager.GetLogger(typeof(Startup));
        private IComputerModel computer;

        /// <summary>
        /// Return the computer with the devices to observe
        /// </summary>
        /// <returns></returns>
        public ComputerModel GetComputer(Computers computers)
        {
            return computers.GetHardware();
        }

        /// <summary>
        /// Visit the required devices and create the set of meters to observe
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="hardwareVisitor"></param>
        /// <returns></returns>
        public IObservableMeters CreateObservableMeters(IComputerModel computer, IHardwareVisitor hardwareVisitor)
        {
            try
            {
                computer.Open();
                computer.Update();
                computer.Traverse(hardwareVisitor);
                return new ObservableMeters(new HardwareConfig(), hardwareVisitor.GetMeters());
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                throw e;
            }
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
        /// <param name="IHardwareVisitor"></param>
        /// <returns></returns>
        public DispatcherTimer CreateTimer(IComputerModel computer, IHardwareVisitor IHardwareVisitor, DispatcherTimer timer)
        {
            // Closure to pass additional values to the update method when the event is raised
            timer.Tick += (s, args) => new ComputerUpdate().Update(computer, IHardwareVisitor);
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
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            logger.Info("NiceMeter application started");

            // Init the computer and its devices
            computer = GetComputer(new Computers());
            var hardwareVisitor = new HardwareVisitor(new HardwareConfig(), new MeterFactory());

            try
            {
                // Init timer and events
                CreateTimer(computer, hardwareVisitor, new DispatcherTimer()).Start();
                // NiceMeter window
                var niceMeterWindow = new NiceMeterWindow(CreateObservableMeters(computer, hardwareVisitor), SystemParameters.WorkArea.Right);
                niceMeterWindow.CreateView();
                niceMeterWindow.Show();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Ensure that a shutdown of thew application correctly frees up the computer resource
        /// </summary>
        /// <param name="exitCode"></param>
        public new void Shutdown(int exitCode)
        {
            computer.Close();
            
            base.Shutdown(exitCode);
        }
    }
}
