using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class VoltUnitTest
    {
        [TestMethod]
        public void Ctor_EmptyValue_ShouldDefaultToNull()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();

            var voltUnit = new VoltUnit(ohName, label);

            Assert.AreEqual(VoltUnit.DefaultMeasurementUnit, voltUnit.measurementUnit);
            Assert.AreEqual(VoltUnit.DefaultFormat, voltUnit.numberFormat);
            Assert.AreEqual(ohName, voltUnit.OHName);
            Assert.AreEqual(label, voltUnit.Label);
            Assert.IsNull(voltUnit.Value);
        }

        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var ohName = new Faker().Random.Word();
            var label = new Faker().Random.Word();
            var value = new Faker().Random.Number();

            var percentUnit = new VoltUnit(ohName, label, value);

            Assert.AreEqual(VoltUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(VoltUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual(ohName, percentUnit.OHName);
            Assert.AreEqual(label, percentUnit.Label);
            Assert.AreEqual(value, percentUnit.Value);
        }
    }
}
