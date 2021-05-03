using System.Collections.ObjectModel;

namespace NiceMeter.Meters
{
    public interface IObservableMeters
    {
        /// <summary>
        /// Return the stored collection of meters
        /// </summary>
        /// <returns></returns>
        ObservableCollection<IMeter> GetMeters();
    }
}
