namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a temperate-based meter value, no precision digits, e.g. 23 °C
    /// </summary>
    public class TempUnit : Unit
    {
        public const string DefaultMeasurementUnit = "°C";
        public const string DefaultFormat = "{0:N0}";

        public TempUnit(string OHName, string Label, float? Value) : base(OHName, Label, Value, DefaultMeasurementUnit, DefaultFormat)
        {
        }
    }
}
