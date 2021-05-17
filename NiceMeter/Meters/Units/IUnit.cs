using System.Globalization;

namespace NiceMeter.Meters.Units
{
    public interface IUnit
    {
        string OHName { get; set; }
        float? Value { get; set; }
        string Label { get; }

        string FormatFloatValue(float? value, string numberFormat, CultureInfo culture = null);

        string ToString();
    }
}
