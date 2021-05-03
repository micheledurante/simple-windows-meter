using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Converters;
using System.Globalization;
using System.Windows.Controls;

namespace NiceMeterTests.Meters.Converters
{
    [TestClass]
    public class SimpleUnitConverterTest
    {
        [TestMethod]
        public void Convert_Default_ShoulConvertWithMeasurementUnit()
        {
            var simpleUnitConverter = new SimpleUnitConverter();
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
