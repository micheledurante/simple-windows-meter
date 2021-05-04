namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a Watt-based meter value with 1-digit precision, e.g. 12,1 %
    /// </summary>
    public class PercentUnit : Unit
    {
        public PercentUnit(string Label, float? Value) : base(Label, Value, "%", "{0:N1}")
        {
        }
    }
}
