using NiceMeter.ViewModels;
using System.Windows;
using System.Windows.Controls;
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

            StatMeters.ItemsSource = Meters.GetMeters();

            var view = (CollectionView)CollectionViewSource.GetDefaultView(StatMeters.ItemsSource);
            var groupDescription = new PropertyGroupDescription("HardwareType");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
