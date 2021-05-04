using NiceMeter.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace NiceMeter.Meters
{
    /// <summary>
    /// Represent the collection of meters observed for changes every tick cycle.
    /// </summary>
    public class ObservableMeters : IObservableMeters
    {
        public readonly HardwareConfig hardwareConfig;
        private readonly ObservableCollection<IMeter> meters;

        public ObservableMeters(HardwareConfig hardwareConfig, ObservableCollection<IMeter> meters = null)
        {
            this.hardwareConfig = hardwareConfig;
            this.meters = meters;
            // Wire up the CollectionChanged event.
            if (meters != null)
            {
                this.meters.CollectionChanged += OnCollectionChanged;
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Implement here logic for adding/removing tables to the collection.
        }

        public ObservableCollection<IMeter> GetMeters()
        {
            return meters;
        }

        public HardwareConfig GetHardwareConfig()
        {
            return hardwareConfig;
        }
    }
}
