using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.ViewModels
{
    public class Unit
    {
        public float? value;
        public string measurementUnit;
        public string format;

        public Unit(float? value, string measurementUnit, string format)
        {
            this.value = value;
            this.measurementUnit = measurementUnit;
            this.format = format;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", string.Format(format, value), measurementUnit);
        }
    }
}
