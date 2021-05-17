using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class PercentUnitTest
    {
        [TestMethod]
        public void Ctor_EmptyValue_ShouldDefaultToNull()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();

            var percentUnit = new PercentUnit(ohName, label);

            Assert.AreEqual(PercentUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(PercentUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual(ohName, percentUnit.OHName);
            Assert.AreEqual(label, percentUnit.Label);
            Assert.IsNull(percentUnit.Value);
        }

        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();
            var value = new Faker().Random.Number();

            var percentUnit = new PercentUnit(ohName, label, value);

            Assert.AreEqual(PercentUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(PercentUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual(ohName, percentUnit.OHName);
            Assert.AreEqual(label, percentUnit.Label);
            Assert.AreEqual(value, percentUnit.Value);
        }
    }
}
