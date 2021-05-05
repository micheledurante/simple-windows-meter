using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class VoltUnitTest
    {
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
