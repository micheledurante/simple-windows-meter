using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Converters;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace NiceMeterTests.Meters.Converters
{
    [TestClass]
    public class TextBlockConverterTest
    {
        [TestMethod]
        public void Ctor_Default_ShouldCreateTheValidTextBlockInstance()
        {
            var textBlock = new TextBlockConverter().GetTextBlock();

            Assert.AreEqual(TextBlockConverter.TAlignment, textBlock.TextAlignment);
            Assert.AreEqual(TextBlockConverter.VAlignment, textBlock.VerticalAlignment);
            Assert.AreEqual(
                new Thickness
                {
                    Left = TextBlockConverter.LeftMargin,
                    Top = TextBlockConverter.TopMargin,
                    Right = TextBlockConverter.RightMargin,
                    Bottom = TextBlockConverter.BottomMargin
                },
                textBlock.Padding
            );
            Assert.AreEqual(TextBlockConverter.Height, textBlock.Height);
            Assert.AreEqual(TextBlockConverter.LineHeight, textBlock.LineHeight);
            Assert.AreEqual(TextBlockConverter.FontSize, textBlock.FontSize);
        }

        [TestMethod]
        public void GetTextBlock_Default_ShouldReturnTheInternalTextBlockObject()
        {
            var textBlock = new TextBlockConverter().GetTextBlock();

            Assert.IsInstanceOfType(textBlock, typeof(TextBlock));
        }

        [TestMethod]
        public void FormatFloatValue_NullCulture_ShouldFormatWithCurrentCulture()
        {
            var TextBlockConverter = new TextBlockConverter();
            float value = 1.234F;
            string numberFormat = "{0:N3}";

            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Assert.AreEqual("1.234", TextBlockConverter.FormatFloatValue(value, numberFormat));
        }

        [TestMethod]
        public void FormatFloatValue_GivenCulture_ShouldFormatWithCulture()
        {
            var TextBlockConverter = new TextBlockConverter();
            float value = 1.234F;
            string numberFormat = "{0:N3}";

            var culture = new CultureInfo("de-DE");

            Assert.AreEqual("1,234", TextBlockConverter.FormatFloatValue(value, numberFormat, culture));
        }

        [TestMethod]
        public void Convert_Default_ShoulConvertWithMeasurementUnit()
        {
            var simpleUnitConverter = new TextBlockConverter();
            float value = 1.234F;
            string numberFormat = "{0:N3}";
            string measurementUnit = "XX";
            var culture = new CultureInfo("de-DE");

            var result = simpleUnitConverter.Convert(value, measurementUnit, numberFormat, culture);

            Assert.IsInstanceOfType(result, typeof(TextBlock));
            Assert.AreEqual("1,234 XX", result.Text);
        }
    }
}
