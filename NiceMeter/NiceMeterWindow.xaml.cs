using log4net;
using NiceMeter.Visitors;
using System;
using System.Windows;
using System.Windows.Data;

namespace NiceMeter
{
    /// <summary>
    /// Interaction logic for NiceMeterWindow.xaml
    /// </summary>
    public partial class NiceMeterWindow : Window
    {
        public const int height = 400;
        public const int left = 0;
        public const int top = 0;
        public const string title = "NiceMeter";
        public const bool allowsTransparency = false;
        public const WindowStyle windowStyle = WindowStyle.None;
        public const ResizeMode resizeMode = ResizeMode.NoResize;
        public const WindowStartupLocation windowStartupLocation = WindowStartupLocation.Manual;

        private readonly IObservableMeters observableMeters;
        private static readonly ILog logger = LogManager.GetLogger(typeof(NiceMeterWindow));

        /// <summary>
        /// Init the NiceMeter window
        /// </summary>
        public NiceMeterWindow(IObservableMeters observableMeters, double workAreaRight)
        {
            this.observableMeters = observableMeters;
            InitializeComponent();
            SetWindowProperties(workAreaRight);
        }

        /// <summary>
        /// Set the visual properties of the NiceMeter window
        /// </summary>
        private void SetWindowProperties(double workAreaRight)
        {
            Height = height;
            Width = workAreaRight;
            Left = left;
            Top = top;
            Title = title;
            WindowStyle = windowStyle;
            ResizeMode = resizeMode;
            WindowStartupLocation = windowStartupLocation;
            AllowsTransparency = allowsTransparency;
        }

        /// <summary>
        /// Create the UI view for the current collection of meters
        /// </summary>
        public void CreateView()
        {
            if (observableMeters == null)
            {
                logger.Error("No observable meters provided. Cannot Create the view");
                Environment.Exit(901);
            }

            statMeters.ItemsSource = observableMeters.GetMeters();

            var view = (CollectionView)CollectionViewSource.GetDefaultView(statMeters.ItemsSource);
            var groupDescription = new PropertyGroupDescription("HardwareType");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
