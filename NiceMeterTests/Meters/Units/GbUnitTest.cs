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
            var tempUnit = new GbUnit("asdfg", "qwe");

            Assert.AreEqual(GbUnit.DefaultMeasurementUnit, tempUnit.measurementUnit);
            Assert.AreEqual(GbUnit.DefaultFormat, tempUnit.numberFormat);
            Assert.AreEqual("qwe", tempUnit.Label);
            Assert.IsNull(tempUnit.Value);
        }

        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var percentUnit = new GbUnit("vcxz", "asd", 34422);

            Assert.AreEqual(GbUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(GbUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual("asd", percentUnit.Label);
            Assert.AreEqual(34422, percentUnit.Value);
        }
    }
}
