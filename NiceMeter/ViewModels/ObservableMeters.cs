using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.ViewModels
{
    class ObservableMeters
    {
        private ObservableCollection<Meter> Meters;

        public ObservableMeters(ObservableCollection<Meter> meters)
        {
            Meters = meters;
            // Wire up the CollectionChanged event.
            Meters.CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Implement here logic for adding/removing tables to the collection.
        }

        public ObservableCollection<Meter> GetMeters()
        {
            return Meters;
        }
    }
}
