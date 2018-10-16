using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.ViewModels
{
    public class Unit
    {
        public string value;
        public string measurementUnit;

        public Unit(string value, string measurementUnit)
        {
            this.value = value;
            this.measurementUnit = measurementUnit;
        }
    }
}
