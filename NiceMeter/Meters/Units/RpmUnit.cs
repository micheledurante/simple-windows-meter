namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent an RPM-based meter value, no precision digits, e.g. 896 RPM
    /// </summary>
    public class RpmUnit : Unit
    {
        public RpmUnit(string Label, float? Value) : base(Label, Value, "RPM", "{0:N0}")
        {
        }
    }
}
