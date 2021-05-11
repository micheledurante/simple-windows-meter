using NiceMeter.Meters.Units;

namespace NiceMeter.Meters.Ram
{
    /// <summary>
    /// Represent a GB-sized meter value with 1-digit precision, e.g. 7.8 GB
    /// </summary>
    public class RamGbUnit : GbUnit
    {
        public RamGbUnit(string OHName, string Label, float? Value = null) : base(OHName, Label, Value)
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
