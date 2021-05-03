using NiceMeter.Meters.Converters;

namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a temperate-based meter value, no precision digits, e.g. 23 °C
    /// </summary>
    public class TempUnit : Unit
    {
        public TempUnit(string Label, float? Value, IUnitConverter unitConverter = null) : base(Label, Value, "°C", "{0:N0}", unitConverter)
        {
        }
    }
}
