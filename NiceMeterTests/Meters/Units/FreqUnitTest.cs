using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class FreqUnitTest
    {
        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var percentUnit = new FreqUnit("qwerty", "asdf", 7755);

            Assert.AreEqual(FreqUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(FreqUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual("asdf", percentUnit.Label);
            Assert.AreEqual(7755, percentUnit.Value);
        }
    }
}
