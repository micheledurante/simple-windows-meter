using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.Interfaces
{
    interface IVisitorObservable
    {
        ObservableCollection<IMeter> UpdateCollection();

        ObservableCollection<IMeter> GetDisplayValue();
    }
}
