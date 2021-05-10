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
            var rpmUnit = new RpmUnit("qwe", "erty");

            Assert.AreEqual(RpmUnit.DefaultMeasurementUnit, rpmUnit.measurementUnit);
            Assert.AreEqual(RpmUnit.DefaultFormat, rpmUnit.numberFormat);
            Assert.AreEqual("erty", rpmUnit.Label);
            Assert.IsNull(rpmUnit.Value);
        }

        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var percentUnit = new RpmUnit("vcxz", "qwerty", 432534543);

            Assert.AreEqual(RpmUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(RpmUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual("qwerty", percentUnit.Label);
            Assert.AreEqual(432534543, percentUnit.Value);
        }
    }
}
