using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeter.Structs
{
    public struct Unit
    {
        public float value;
        public string measurementUnit;

        public Unit(float value, string measurementUnit)
        {
            this.value = value;
            this.measurementUnit = measurementUnit;
        }
    }
}
