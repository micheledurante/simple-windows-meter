using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class WattUnitTest
    {
        [TestMethod]
        public void Ctor_EmptyValue_ShouldDefaultToNull()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();

            var wattUnit = new WattUnit(ohName, label);

            Assert.AreEqual(WattUnit.DefaultMeasurementUnit, wattUnit.measurementUnit);
            Assert.AreEqual(WattUnit.DefaultFormat, wattUnit.numberFormat);
            Assert.AreEqual(ohName, wattUnit.OHName);
            Assert.AreEqual(label, wattUnit.Label);
            Assert.IsNull(wattUnit.Value);

        }
        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();
            var value = new Faker().Random.Number();

            var percentUnit = new WattUnit(ohName, label, value);

            Assert.AreEqual(WattUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(WattUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual(ohName, percentUnit.OHName);
            Assert.AreEqual(label, percentUnit.Label);
            Assert.AreEqual(value, percentUnit.Value);
        }
    }
}
