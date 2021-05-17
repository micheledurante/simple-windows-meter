using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class FreqUnitTest
    {
        [TestMethod]
        public void Ctor_EmptyValue_ShouldDefaultToNull()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();

            var freqUnit = new FreqUnit(ohName, label);

            Assert.AreEqual(FreqUnit.DefaultMeasurementUnit, freqUnit.measurementUnit);
            Assert.AreEqual(FreqUnit.DefaultFormat, freqUnit.numberFormat);
            Assert.AreEqual(ohName, freqUnit.OHName);
            Assert.AreEqual(label, freqUnit.Label);
            Assert.IsNull(freqUnit.Value);
        }

        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();
            var value = new Faker().Random.Number();

            var freqUnit = new FreqUnit(ohName, label, value);

            Assert.AreEqual(FreqUnit.DefaultMeasurementUnit, freqUnit.measurementUnit);
            Assert.AreEqual(FreqUnit.DefaultFormat, freqUnit.numberFormat);
            Assert.AreEqual(ohName, freqUnit.OHName);
            Assert.AreEqual(label, freqUnit.Label);
            Assert.AreEqual(value, freqUnit.Value);
        }
    }
}
