using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class TempUnitTest
    {
        [TestMethod]
        public void Ctor_EmptyValue_ShouldDefaultToNull()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();

            var tempUnit = new TempUnit(ohName, label);

            Assert.AreEqual(TempUnit.DefaultMeasurementUnit, tempUnit.measurementUnit);
            Assert.AreEqual(TempUnit.DefaultFormat, tempUnit.numberFormat);
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

            var percentUnit = new TempUnit(ohName, label, value);

            Assert.AreEqual(TempUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(TempUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual(ohName, percentUnit.OHName);
            Assert.AreEqual(label, percentUnit.Label);
            Assert.AreEqual(value, percentUnit.Value);
        }
    }
}
