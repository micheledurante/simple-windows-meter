using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace NiceMeter.ViewModels
{
    /// <summary>
    /// Represent the collection of meters observed for changes every tick cycle.
    /// </summary>
    public class ObservableMeters : IObservableMeters
    {
        private readonly ObservableCollection<IMeter> meters;

        public ObservableMeters(ObservableCollection<IMeter> meters = null)
        {
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
    }
}
