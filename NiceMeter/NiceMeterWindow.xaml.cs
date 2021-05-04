using log4net;
using NiceMeter.Meters;
using NiceMeter.Meters.Cpu;
using NiceMeter.Meters.Mainboard;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace NiceMeter
{
    /// <summary>
    /// Interaction logic for NiceMeterWindow.xaml
    /// </summary>
    public partial class NiceMeterWindow : Window
    {
        public const int height = 14;
        public const int left = 0;
        public const int top = 0;
        public const string title = "NiceMeter";
        public const bool allowsTransparency = true;
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
            Topmost = true;
        }

        /// <summary>
        /// Create the UI elements and bindings for the Mainboard meters
        /// </summary>
        public void CreateMainboardPanel()
        {
            mainboardPanel.DataContext = (MainboardMeters)observableMeters.GetMeters()[0];

            mainboardPanel.Children.Add(new TextBlock(new Run("  "))); // spacer

            var mainboardNameTextBlock = new TextBlock();
            mainboardNameTextBlock.Foreground = Brushes.White;
            mainboardNameTextBlock.LineHeight = 10;
            mainboardNameTextBlock.FontSize = 10;
            mainboardNameTextBlock.FontWeight = FontWeights.Light;

            Binding mainboardNameBinding = new Binding("Name")
            {
                Source = mainboardPanel.DataContext
            };
            mainboardNameBinding.Mode = BindingMode.Default;
            mainboardNameTextBlock.SetBinding(TextBlock.TextProperty, mainboardNameBinding);

            mainboardPanel.Children.Add(mainboardNameTextBlock); // Mainboard name
        }

        /// <summary>
        /// Create the UI elements and bindings for the CPU meters
        /// </summary>
        public void CreateCpuPanel()
        {
            var cpuMeters = (CpuMeters)observableMeters.GetMeters()[1];

            cpuPanel.DataContext = cpuMeters;

            var dividerTextBlock = new TextBlock();
            dividerTextBlock.Foreground = Brushes.White;
            dividerTextBlock.LineHeight = 10;
            dividerTextBlock.FontSize = 10;
            dividerTextBlock.FontWeight = FontWeights.Light;
            dividerTextBlock.Text = "  |  ";

            cpuPanel.Children.Add(dividerTextBlock); // divider

            var cpuNameTextBlock = new TextBlock();
            cpuNameTextBlock.Foreground = Brushes.White;
            cpuNameTextBlock.LineHeight = 10;
            cpuNameTextBlock.FontSize = 10;
            cpuNameTextBlock.FontWeight = FontWeights.Light;

            Binding cpuNameBinding = new Binding("Name")
            {
                Source = cpuPanel.DataContext
            };
            cpuNameBinding.Mode = BindingMode.Default;
            cpuNameTextBlock.SetBinding(TextBlock.TextProperty, cpuNameBinding);

            cpuPanel.Children.Add(cpuNameTextBlock); // CPU text

            cpuPanel.Children.Add(new TextBlock(new Run("  "))); // spacer

            var cpuTotalBlock = new TextBlock();
            cpuTotalBlock.Foreground = Brushes.White;
            cpuTotalBlock.LineHeight = 10;
            cpuTotalBlock.FontSize = 10;
            cpuTotalBlock.FontWeight = FontWeights.Light;

            Binding cpuTotalBinding = new Binding("Text")
            {
                Source = cpuPanel.DataContext
            };
            cpuTotalBinding.Mode = BindingMode.OneWay;
            cpuTotalBinding.NotifyOnSourceUpdated = true;
            cpuTotalBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            cpuTotalBlock.SetBinding(TextBlock.TextProperty, cpuTotalBinding);

            cpuPanel.Children.Add(cpuTotalBlock);
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

            if (observableMeters.GetHardwareConfig().MainboardEnabled)
            {
                CreateMainboardPanel();
            }

            if (observableMeters.GetHardwareConfig().CPUEnabled)
            {
                CreateCpuPanel();
            }
        }
    }
}
