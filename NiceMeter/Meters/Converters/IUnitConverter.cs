using System.Windows.Controls;

namespace NiceMeter.Meters.Converters
{
    /// <summary>
    /// Convert a Unit object to a WPF TextBlock for display
    /// </summary>
    public interface IUnitConverter
    {
        /// <summary>
        /// Convert the given float value accoring to the given number format, measurement unit and culture
        /// </summary>
        /// <param name="value"></param>
        /// <param name="measurementUnit"></param>
        /// <param name="numberFormat"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        TextBlock Convert(float? value, string measurementUnit, string numberFormat, System.Globalization.CultureInfo culture = null);

        /// <summary>
        /// Return the instance of the internal TextBlock
        /// </summary>
        /// <returns></returns>
        TextBlock GetTextBlock();
    }
}
