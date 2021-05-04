namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent an RPM-based meter value, no precision digits, e.g. 896 RPM
    /// </summary>
    public class RpmUnit : Unit
    {
        public const string DefaultMeasurementUnit = "RPM";
        public const string DefaultFormat = "{0:N0}";
        public RpmUnit(string Label, float? Value) : base(Label, Value, DefaultMeasurementUnit, DefaultFormat)
        {
        }
    }
}
