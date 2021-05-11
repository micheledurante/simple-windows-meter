namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a GB-sized meter value with 1-digit precision, e.g. 7.8 GB
    /// </summary>
    public class GbUnit : Unit
    {
        public const string DefaultMeasurementUnit = "GB";
        public const string DefaultFormat = "{0:N1}";

        public GbUnit(string OHName, string Label, float? Value = null) : base(OHName, Label, Value, DefaultMeasurementUnit, DefaultFormat)
        {
        }
    }
}
