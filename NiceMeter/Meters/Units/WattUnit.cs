namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a Watt-based meter value, no precision digits, e.g. 23 W
    /// </summary>
    public class WattUnit : Unit
    {
        public WattUnit(string Label, float? Value) : base(Label, Value, "W", "{0:N0}")
        {
        }
    }
}
