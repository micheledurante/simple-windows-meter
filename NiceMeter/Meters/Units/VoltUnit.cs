using NiceMeter.Meters.Converters;

namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a voltage-based meter value with a 3-digit precision, e.g. 1.080 V
    /// </summary>
    public class VoltUnit : Unit
    {
        public VoltUnit(string Label, float? Value, IUnitConverter unitConverter = null) : base(Label, Value, "V", "{0:N3}", unitConverter)
        {
        }
    }
}
