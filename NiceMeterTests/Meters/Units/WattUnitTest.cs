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
            var wattUnit = new WattUnit("asdf", "qwerty");

            Assert.AreEqual(WattUnit.DefaultMeasurementUnit, wattUnit.measurementUnit);
            Assert.AreEqual(WattUnit.DefaultFormat, wattUnit.numberFormat);
            Assert.AreEqual("qwerty", wattUnit.Label);
            Assert.IsNull(wattUnit.Value);

        }
        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var percentUnit = new WattUnit("asdf", "ytrewq", 3443);

            Assert.AreEqual(WattUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(WattUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual("ytrewq", percentUnit.Label);
            Assert.AreEqual(3443, percentUnit.Value);
        }
    }
}
