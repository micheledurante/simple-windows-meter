using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class GbUnitTest
    {
        [TestMethod]
        public void Ctor_EmptyValue_ShouldDefaultToNull()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();

            var tempUnit = new GbUnit(ohName, label);

            Assert.AreEqual(GbUnit.DefaultMeasurementUnit, tempUnit.measurementUnit);
            Assert.AreEqual(GbUnit.DefaultFormat, tempUnit.numberFormat);
            Assert.AreEqual(ohName, tempUnit.OHName);
            Assert.AreEqual(label, tempUnit.Label);
            Assert.IsNull(tempUnit.Value);
        }

        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();
            var value = new Faker().Random.Number();

            var percentUnit = new GbUnit(ohName, label, value);

            Assert.AreEqual(GbUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(GbUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual(ohName, percentUnit.OHName);
            Assert.AreEqual(label, percentUnit.Label);
            Assert.AreEqual(value, percentUnit.Value);
        }
    }
}
