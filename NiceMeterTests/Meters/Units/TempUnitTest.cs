using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class TempUnitTest
    {
        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var percentUnit = new TempUnit("zxcv", 233532);

            Assert.AreEqual(TempUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(TempUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual("zxcv", percentUnit.Label);
            Assert.AreEqual(233532, percentUnit.Value);
        }
    }
}
