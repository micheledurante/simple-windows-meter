using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace NiceMeter.Meters.Converters
{
    public abstract class BaseConverter : IUnitConverter
    {
        public const TextAlignment TAlignment = TextAlignment.Left;
        public const VerticalAlignment VAlignment = VerticalAlignment.Center;
        public const double LeftMargin = 0;
        public const double TopMargin = 0;
        public const double RightMargin = 8;
        public const double BottomMargin = 0;
        public const double Height = 16;
        public const double LineHeight = 16;
        public const double FontSize = 13;
        //public FontWeight Weight = FontWeight.FromOpenTypeWeight(1);

        /// <summary>
        /// The internal, default instance of a TextBlock
        /// </summary>
        protected TextBlock textBlock;
        public abstract TextBlock Convert(float? value, string measurementUnit, string numberFormat, CultureInfo culture = null);

        public BaseConverter()
        {
            textBlock = new TextBlock
            {
                TextAlignment = TAlignment,
                VerticalAlignment = VAlignment,
                Height = Height,
                LineHeight = LineHeight,
                FontSize = FontSize,
                //FontWeight = Weight,
                Padding = new Thickness { Left = LeftMargin, Top = TopMargin, Right = RightMargin, Bottom = BottomMargin }
            };
        }

        /// <inheritdoc/>
        public TextBlock GetTextBlock()
        {
            return textBlock;
        }

        /// <summary>
        /// Format the given float value according to the given number format and culture
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberFormat"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public string FormatFloatValue(float? value, string numberFormat, CultureInfo culture = null)
        {
            return string.Format(culture ?? Thread.CurrentThread.CurrentCulture, numberFormat, value);
        }
    }
}
