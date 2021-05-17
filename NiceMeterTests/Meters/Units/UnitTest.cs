using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;
using System.Globalization;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Ctor_ValidParameters_PropertiesAreSetAsExpected()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();
            var value = new Faker().Random.Number();
            var measurementUnit = new Faker().Random.Word();
            var numberFormat = new Faker().Random.Word();

            var unit = new Unit(ohName, label, value, measurementUnit, numberFormat);

            Assert.AreEqual(ohName, unit.OHName);
            Assert.AreEqual(label, unit.Label);
            Assert.AreEqual(value, unit.Value);
            Assert.AreEqual(measurementUnit, unit.measurementUnit);
            Assert.AreEqual(numberFormat, unit.numberFormat);
        }

        [TestMethod]
        public void FormatFloatValue_NullCulture_ShouldFormatWithCurrentCulture()
        {
            var unit = new Unit(new Faker().Random.Word(), new Faker().Random.Word(), 1234123, new Faker().Random.Word(), new Faker().Random.Word());
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
            var unit = new Unit(new Faker().Random.Word(), new Faker().Random.Word(), 1234123, new Faker().Random.Word(), new Faker().Random.Word());
            float value = 1.234F;
            string numberFormat = "{0:N3}";

            var culture = new CultureInfo("de-DE");

            Assert.AreEqual("1,234", unit.FormatFloatValue(value, numberFormat, culture));
        }

        [TestMethod]
        public void ToString_GivenCulture_ShouldFormatWithThreadsCulture()
        {
            var label = new Faker().Random.Word();

            var unit = new Unit(new Faker().Random.Word(), label, 1.234F, "V", "{0:N3}");

            var culture = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Assert.AreEqual(string.Format("{0}: 1,234 V", label), unit.ToString());
        }
    }
}
