using NiceMeter.Meters.Units;

namespace NiceMeter.Meters.Ram
{
    /// <summary>
    /// Represent a Watt-based meter value with 1-digit precision, e.g. 12,1 %
    /// </summary>
    public class RamPercentUnit : PercentUnit
    {
        public RamPercentUnit(string OHName, string Label, float? Value = null) : base(OHName, Label, Value)
        {
        }

        /// <summary>
        /// Slightly modify the appearance of the formatted meters
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{1} {2}", Label, FormatFloatValue(Value, numberFormat), measurementUnit);
        }
    }
}
