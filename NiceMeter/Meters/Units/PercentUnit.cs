namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a Watt-based meter value with 1-digit precision, e.g. 12,1 %
    /// </summary>
    public class PercentUnit : Unit
    {
        public const string DefaultMeasurementUnit = "%";
        public const string DefaultFormat = "{0:N1}";

        public PercentUnit(string OHName, string Label, float? Value) : base(OHName, Label, Value, DefaultMeasurementUnit, DefaultFormat)
        {
        }
    }
}
