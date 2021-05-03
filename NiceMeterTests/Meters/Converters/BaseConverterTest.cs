using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Converters;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace NiceMeterTests.Meters.Converters
{
    [TestClass]
    public class BaseConverterTest
    {
        [TestMethod]
        public void Ctor_Default_ShouldCreateTheValidTextBlockInstance()
        {
            var textBlock = new BaseConverterMock().GetTextBlock();

            Assert.AreEqual(BaseConverter.TAlignment, textBlock.TextAlignment);
            Assert.AreEqual(BaseConverter.VAlignment, textBlock.VerticalAlignment);
            Assert.AreEqual(
                new Thickness { 
                    Left = BaseConverter.LeftMargin, 
                    Top = BaseConverter.TopMargin, 
                    Right = BaseConverter.RightMargin,
                    Bottom = BaseConverter.BottomMargin 
                },
                textBlock.Padding
            );
            Assert.AreEqual(BaseConverter.Height, textBlock.Height);
            Assert.AreEqual(BaseConverter.LineHeight, textBlock.LineHeight);
            Assert.AreEqual(BaseConverter.FontSize, textBlock.FontSize);
        }

        [TestMethod]
        public void GetTextBlock_Default_ShouldReturnTheInternalTextBlockObject()
        {
            var textBlock = new BaseConverterMock().GetTextBlock();

            Assert.IsInstanceOfType(textBlock, typeof(TextBlock));
        }

        [TestMethod]
        public void FormatFloatValue_NullCulture_ShouldFormatWithCurrentCulture()
        {
            var baseConverterMock = new BaseConverterMock();
            float value = 1.234F;
            string numberFormat = "{0:N3}";

            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Assert.AreEqual("1.234", baseConverterMock.FormatFloatValue(value, numberFormat));
        }

        [TestMethod]
        public void FormatFloatValue_GivenCulture_ShouldFormatWithCulture()
        {
            var baseConverterMock = new BaseConverterMock();
            float value = 1.234F;
            string numberFormat = "{0:N3}";

            var culture = new CultureInfo("de-DE");

            Assert.AreEqual("1,234", baseConverterMock.FormatFloatValue(value, numberFormat, culture));
        }
    }
}
