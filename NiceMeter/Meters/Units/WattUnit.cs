namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a Watt-based meter value, no precision digits, e.g. 23 W
    /// </summary>
    public class WattUnit : Unit
    {
        public const string DefaultMeasurementUnit = "W";
        public const string DefaultFormat = "{0:N0}";

        public WattUnit(string Label, float? Value) : base(Label, Value, DefaultMeasurementUnit, DefaultFormat)
        {
        }
    }
}
