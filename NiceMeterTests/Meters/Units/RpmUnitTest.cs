using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class RpmUnitTest
    {
        [TestMethod]
        public void Ctor_EmptyValue_ShouldDefaultToNull()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();

            var rpmUnit = new RpmUnit(ohName, label);

            Assert.AreEqual(RpmUnit.DefaultMeasurementUnit, rpmUnit.measurementUnit);
            Assert.AreEqual(RpmUnit.DefaultFormat, rpmUnit.numberFormat);
            Assert.AreEqual(ohName, rpmUnit.OHName);
            Assert.AreEqual(label, rpmUnit.Label);
            Assert.IsNull(rpmUnit.Value);
        }

        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();
            var value = new Faker().Random.Number();

            var percentUnit = new RpmUnit(ohName, label, value);

            Assert.AreEqual(RpmUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(RpmUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual(ohName, percentUnit.OHName);
            Assert.AreEqual(label, percentUnit.Label);
            Assert.AreEqual(value, percentUnit.Value);
        }
    }
}
