using System.Globalization;

namespace NiceMeter.Meters.Units
{
    public interface IUnit
    {
        string FormatFloatValue(float? value, string numberFormat, CultureInfo culture = null);

        string ToString();
    }
}
