using System.Globalization;
using System.Windows.Controls;

namespace NiceMeter.Meters.Converters
{
    /// <summary>
    /// The simplest converter to convert a Unit to TextBlock
    /// </summary>
    public class SimpleUnitConverter : BaseConverter
    {
        /// <inheritdoc/>
        public override TextBlock Convert(float? value, string measurementUnit, string numberFormat, CultureInfo culture = null)
        {
            textBlock.Text = string.Format("{0} {1}", FormatFloatValue(value, numberFormat, culture), measurementUnit);
            return textBlock;
        }
    }
}
