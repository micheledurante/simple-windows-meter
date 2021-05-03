using log4net;
using NiceMeter.Meters;
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
        /// Create the UI view for the current collection of meters
        /// </summary>
        public void CreateView()
        {
            if (observableMeters == null)
            {
                logger.Error("No observable meters provided. Cannot Create the view");
                Environment.Exit(901);
            }

            // Mainboard panel

            mainboardPanel.DataContext = observableMeters.GetMeters()[0];

            cpuPanel.Children.Add(new TextBlock(new Run("  "))); // spacer

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

            cpuPanel.Children.Add(mainboardNameTextBlock); // Mainboard name

            cpuPanel.Children.Add(new TextBlock(new Run("  "))); // spacer

            var mainboardTextTextBlock = new TextBlock();
            mainboardTextTextBlock.Foreground = Brushes.White;
            mainboardTextTextBlock.LineHeight = 10;
            mainboardTextTextBlock.FontSize = 10;
            mainboardTextTextBlock.FontWeight = FontWeights.Light;

            Binding mainboardTextBinding = new Binding("Text")
            {
                Source = mainboardPanel.DataContext
            };
            mainboardTextBinding.Mode = BindingMode.OneWay;
            mainboardTextBinding.NotifyOnSourceUpdated = true;
            mainboardTextBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            mainboardTextTextBlock.SetBinding(TextBlock.TextProperty, mainboardTextBinding);

            cpuPanel.Children.Add(mainboardTextTextBlock); // Mainboard Text

            // CPU panel

            cpuPanel.DataContext = observableMeters.GetMeters()[1];

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

            cpuPanel.Children.Add(cpuNameTextBlock); // CPU name


            cpuPanel.Children.Add(new TextBlock(new Run("  "))); // spacer

            var cpuTextTextBlock = new TextBlock();
            cpuTextTextBlock.Foreground = Brushes.White;
            cpuTextTextBlock.LineHeight = 10;
            cpuTextTextBlock.FontSize = 10;
            cpuTextTextBlock.FontWeight = FontWeights.Light;

            Binding cpuTextBinding = new Binding("Text")
            {
                Source = cpuPanel.DataContext
            };
            cpuTextBinding.Mode = BindingMode.OneWay;
            cpuTextBinding.NotifyOnSourceUpdated = true;
            cpuTextBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            cpuTextTextBlock.SetBinding(TextBlock.TextProperty, cpuTextBinding);

            cpuPanel.Children.Add(cpuTextTextBlock); // CPU Text

            // end CPU panel
        }
    }
}
