using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;
using System.Globalization;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void FormatFloatValue_NullCulture_ShouldFormatWithCurrentCulture()
        {
            var unit = new Unit("asd", 1234123, "", "");
            float value = 1.234F;
            string numberFormat = "{0:N3}";

            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Assert.AreEqual("1.234", unit.FormatFloatValue(value, numberFormat));
        }

        [TestMethod]
        public void FormatFloatValue_GivenCulture_ShouldFormatWithCulture()
        {
            var unit = new Unit("asd", 1234123, "", "");
            float value = 1.234F;
            string numberFormat = "{0:N3}";

            var culture = new CultureInfo("de-DE");

            Assert.AreEqual("1,234", unit.FormatFloatValue(value, numberFormat, culture));
        }

        [TestMethod]
        public void ToString_GivenCulture_ShouldFormatWithThreadsCulture()
        {
            var unit = new Unit("asd", 1.234F, "V", "{0:N3}");

            var culture = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Assert.AreEqual("asd: 1,234 V", unit.ToString());
        }
    }
}
