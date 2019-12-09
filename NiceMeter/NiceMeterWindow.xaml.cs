using NiceMeter.ViewModels;
using System.Windows;
using System.Windows.Data;

namespace NiceMeter
{
    /// <summary>
    /// Interaction logic for NiceMeterWindow.xaml
    /// </summary>
    public partial class NiceMeterWindow : Window
    {
        /// <summary>
        /// Start the window
        /// </summary>
        public NiceMeterWindow(ObservableMeters Meters)
        {
            InitializeComponent();

            // Position the window top-right.
            Left = SystemParameters.WorkArea.Right - Width;
            Top = 0;

            StatMeters.ItemsSource = Meters.GetMeters();

            var view = (CollectionView)CollectionViewSource.GetDefaultView(StatMeters.ItemsSource);
            var groupDescription = new PropertyGroupDescription("HardwareType");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
