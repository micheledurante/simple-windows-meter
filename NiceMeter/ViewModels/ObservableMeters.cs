using NiceMeter.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace NiceMeter.ViewModels
{
    public class ObservableMeters
    {
        private ObservableCollection<IDictionary<int, IMeter>> meters;

        public ObservableMeters(ObservableCollection<IDictionary<int, IMeter>> meters)
        {
            this.meters = meters;
            // Wire up the CollectionChanged event.
            this.meters.CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Implement here logic for adding/removing tables to the collection.
        }

        public ObservableCollection<IDictionary<int, IMeter>> GetMeters()
        {
            return meters;
        }
    }
}
