namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a Hertz-based meter value with 2-digit precision shown in GHz, e.g. 4.29 GHz
    /// </summary>
    public class FreqUnit : Unit
    {
        public const string DefaultMeasurementUnit = "GHz";
        public const string DefaultFormat = "{0:N2}";

        public FreqUnit(string OHName, string Label, float? Value) : base(OHName, Label, Value, DefaultMeasurementUnit, DefaultFormat)
        {
        }
    }
}
