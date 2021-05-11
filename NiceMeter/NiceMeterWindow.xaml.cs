using log4net;
using NiceMeter.Meters;
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
        public const bool allowsTransparency = false;
        public const bool topmost = true;
        public const WindowStyle windowStyle = WindowStyle.None;
        public const ResizeMode resizeMode = ResizeMode.NoResize;
        public const WindowStartupLocation windowStartupLocation = WindowStartupLocation.Manual;
        public Brush background = Brushes.Black;

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
            Topmost = topmost;
            Background = background;
        }

        /// <summary>
        /// Create the UI elements and bindings for the Mainboard meters
        /// </summary>
        public void CreateMainboardPanel()
        {
            mainboardPanel.DataContext = observableMeters.GetMainboardMeter();

            mainboardPanel.Children.Add(new TextBlock(new Run("  "))); // spacer

            var mainboardNameTextBlock = new TextBlock();
            mainboardNameTextBlock.Foreground = Brushes.White;
            mainboardNameTextBlock.LineHeight = NiceMeterWindow.height;
            mainboardNameTextBlock.FontSize = 9;
            mainboardNameTextBlock.FontWeight = FontWeights.Light;

            Binding mainboardNameBinding = new Binding("Name")
            {
                Source = mainboardPanel.DataContext
            };
            mainboardNameBinding.Mode = BindingMode.Default;
            mainboardNameTextBlock.SetBinding(TextBlock.TextProperty, mainboardNameBinding);

            mainboardPanel.Children.Add(mainboardNameTextBlock); // Mainboard name

            mainboardPanel.Children.Add(new TextBlock(new Run("  "))); // spacer

            var mainboardTextTextBlock = new TextBlock();
            mainboardTextTextBlock.Foreground = Brushes.White;
            mainboardTextTextBlock.LineHeight = NiceMeterWindow.height;
            mainboardTextTextBlock.FontSize = 9;
            mainboardTextTextBlock.FontWeight = FontWeights.Light;

            Binding mainboardTextBinding = new Binding("Text")
            {
                Source = mainboardPanel.DataContext
            };
            mainboardTextBinding.Mode = BindingMode.OneWay;
            mainboardTextBinding.NotifyOnSourceUpdated = true;
            mainboardTextBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            mainboardTextTextBlock.SetBinding(TextBlock.TextProperty, mainboardTextBinding);

            mainboardPanel.Children.Add(mainboardTextTextBlock); // Mainboard text
        }

        /// <summary>
        /// Create the UI elements and bindings for the RAM meters
        /// </summary>
        public void CreateRamPanel()
        {
            ramPanel.DataContext = observableMeters.GetRamMeter();

            var dividerTextBlock = new TextBlock();
            dividerTextBlock.Foreground = Brushes.White;
            dividerTextBlock.LineHeight = NiceMeterWindow.height;
            dividerTextBlock.FontSize = 9;
            dividerTextBlock.FontWeight = FontWeights.Light;
            dividerTextBlock.Text = "  |  ";

            ramPanel.Children.Add(dividerTextBlock); // divider

            var ramNameTextBlock = new TextBlock();
            ramNameTextBlock.Foreground = Brushes.White;
            ramNameTextBlock.LineHeight = NiceMeterWindow.height;
            ramNameTextBlock.FontSize = 9;
            ramNameTextBlock.FontWeight = FontWeights.Light;

            Binding mainboardNameBinding = new Binding("Name")
            {
                Source = ramPanel.DataContext
            };
            mainboardNameBinding.Mode = BindingMode.Default;
            ramNameTextBlock.SetBinding(TextBlock.TextProperty, mainboardNameBinding);

            ramPanel.Children.Add(ramNameTextBlock); // RAM name

            ramPanel.Children.Add(new TextBlock(new Run("  "))); // spacer

            var ramTextTextBlock = new TextBlock();
            ramTextTextBlock.Foreground = Brushes.White;
            ramTextTextBlock.LineHeight = NiceMeterWindow.height;
            ramTextTextBlock.FontSize = 9;
            ramTextTextBlock.FontWeight = FontWeights.Light;

            Binding mainboardTextBinding = new Binding("Text")
            {
                Source = ramPanel.DataContext
            };
            mainboardTextBinding.Mode = BindingMode.OneWay;
            mainboardTextBinding.NotifyOnSourceUpdated = true;
            mainboardTextBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            ramTextTextBlock.SetBinding(TextBlock.TextProperty, mainboardTextBinding);

            ramPanel.Children.Add(ramTextTextBlock); // RAM text
        }

        /// <summary>
        /// Create the UI elements and bindings for the HDD meters
        /// </summary>
        public void CreateHddPanel()
        {
            hddPanel.DataContext = observableMeters.GetHddMeter();

            var dividerTextBlock = new TextBlock();
            dividerTextBlock.Foreground = Brushes.White;
            dividerTextBlock.LineHeight = NiceMeterWindow.height;
            dividerTextBlock.FontSize = 9;
            dividerTextBlock.FontWeight = FontWeights.Light;
            dividerTextBlock.Text = "  |  ";

            hddPanel.Children.Add(dividerTextBlock); // divider

            var ramNameTextBlock = new TextBlock();
            ramNameTextBlock.Foreground = Brushes.White;
            ramNameTextBlock.LineHeight = NiceMeterWindow.height;
            ramNameTextBlock.FontSize = 9;
            ramNameTextBlock.FontWeight = FontWeights.Light;

            Binding mainboardNameBinding = new Binding("Name")
            {
                Source = hddPanel.DataContext
            };
            mainboardNameBinding.Mode = BindingMode.Default;
            ramNameTextBlock.SetBinding(TextBlock.TextProperty, mainboardNameBinding);

            hddPanel.Children.Add(ramNameTextBlock); // HDD name

            hddPanel.Children.Add(new TextBlock(new Run("  "))); // spacer

            var ramTextTextBlock = new TextBlock();
            ramTextTextBlock.Foreground = Brushes.White;
            ramTextTextBlock.LineHeight = NiceMeterWindow.height;
            ramTextTextBlock.FontSize = 9;
            ramTextTextBlock.FontWeight = FontWeights.Light;

            Binding mainboardTextBinding = new Binding("Text")
            {
                Source = hddPanel.DataContext
            };
            mainboardTextBinding.Mode = BindingMode.OneWay;
            mainboardTextBinding.NotifyOnSourceUpdated = true;
            mainboardTextBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            ramTextTextBlock.SetBinding(TextBlock.TextProperty, mainboardTextBinding);

            hddPanel.Children.Add(ramTextTextBlock); // HDD text
        }

        /// <summary>
        /// Create the UI elements and bindings for the CPU meters
        /// </summary>
        public void CreateCpuPanel()
        {
            cpuPanel.DataContext = observableMeters.GetCpuMeter();

            var dividerTextBlock = new TextBlock();
            dividerTextBlock.Foreground = Brushes.White;
            dividerTextBlock.LineHeight = NiceMeterWindow.height;
            dividerTextBlock.FontSize = 9;
            dividerTextBlock.FontWeight = FontWeights.Light;
            dividerTextBlock.Text = "  |  ";

            cpuPanel.Children.Add(dividerTextBlock); // divider

            var cpuNameTextBlock = new TextBlock();
            cpuNameTextBlock.Foreground = Brushes.White;
            cpuNameTextBlock.LineHeight = NiceMeterWindow.height;
            cpuNameTextBlock.FontSize = 9;
            cpuNameTextBlock.FontWeight = FontWeights.Light;

            Binding cpuNameBinding = new Binding("Name")
            {
                Source = cpuPanel.DataContext
            };
            cpuNameBinding.Mode = BindingMode.Default;
            cpuNameTextBlock.SetBinding(TextBlock.TextProperty, cpuNameBinding);

            cpuPanel.Children.Add(cpuNameTextBlock); // CPU name

            cpuPanel.Children.Add(new TextBlock(new Run("  "))); // spacer

            var cpuTextTextBlock = new TextBlock();
            cpuTextTextBlock.Foreground = Brushes.White;
            cpuTextTextBlock.LineHeight = NiceMeterWindow.height;
            cpuTextTextBlock.FontSize = 9;
            cpuTextTextBlock.FontWeight = FontWeights.Light;

            Binding cpuTextBinding = new Binding("Text")
            {
                Source = cpuPanel.DataContext
            };
            cpuTextBinding.Mode = BindingMode.OneWay;
            cpuTextBinding.NotifyOnSourceUpdated = true;
            cpuTextBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            cpuTextTextBlock.SetBinding(TextBlock.TextProperty, cpuTextBinding);

            cpuPanel.Children.Add(cpuTextTextBlock); // CPU text
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

            if (observableMeters.GetHardwareConfig().RAMEnabled)
            {
                CreateRamPanel();
            }

            if (observableMeters.GetHardwareConfig().HDDEnabled)
            {
                CreateHddPanel();
            }

            if (observableMeters.GetHardwareConfig().CPUEnabled)
            {
                CreateCpuPanel();
            }
        }
    }
}
