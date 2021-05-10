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
            var voltUnit = new VoltUnit("qwe", "qwe");

            Assert.AreEqual(VoltUnit.DefaultMeasurementUnit, voltUnit.measurementUnit);
            Assert.AreEqual(VoltUnit.DefaultFormat, voltUnit.numberFormat);
            Assert.AreEqual("qwe", voltUnit.Label);
            Assert.IsNull(voltUnit.Value);
        }

        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var percentUnit = new VoltUnit("fdsa", "asdf", 89768678);

            Assert.AreEqual(VoltUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(VoltUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual("asdf", percentUnit.Label);
            Assert.AreEqual(89768678, percentUnit.Value);
        }
    }
}
