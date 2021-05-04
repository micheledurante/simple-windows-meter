namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a voltage-based meter value with 3-digit precision, e.g. 1.080 V
    /// </summary>
    public class VoltUnit : Unit
    {
        public const string DefaultMeasurementUnit = "V";
        public const string DefaultFormat = "{0:N3}";
        public VoltUnit(string Label, float? Value) : base(Label, Value, DefaultMeasurementUnit, DefaultFormat)
        {
        }
    }
}
