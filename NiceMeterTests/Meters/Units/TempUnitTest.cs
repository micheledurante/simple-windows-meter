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
            var tempUnit = new TempUnit("fdsa", "zxcv");

            Assert.AreEqual(TempUnit.DefaultMeasurementUnit, tempUnit.measurementUnit);
            Assert.AreEqual(TempUnit.DefaultFormat, tempUnit.numberFormat);
            Assert.AreEqual("zxcv", tempUnit.Label);
            Assert.IsNull(tempUnit.Value);
        }

        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var percentUnit = new TempUnit("qwe", "zxcv", 233532);

            Assert.AreEqual(TempUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(TempUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual("zxcv", percentUnit.Label);
            Assert.AreEqual(233532, percentUnit.Value);
        }
    }
}
