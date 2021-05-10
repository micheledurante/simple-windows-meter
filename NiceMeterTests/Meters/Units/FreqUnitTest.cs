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
            var freqUnit = new FreqUnit("asd", "zxczx");

            Assert.AreEqual(FreqUnit.DefaultMeasurementUnit, freqUnit.measurementUnit);
            Assert.AreEqual(FreqUnit.DefaultFormat, freqUnit.numberFormat);
            Assert.AreEqual("zxczx", freqUnit.Label);
            Assert.IsNull(freqUnit.Value);
        }

        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var freqUnit = new FreqUnit("qwerty", "asdf", 7755);

            Assert.AreEqual(FreqUnit.DefaultMeasurementUnit, freqUnit.measurementUnit);
            Assert.AreEqual(FreqUnit.DefaultFormat, freqUnit.numberFormat);
            Assert.AreEqual("asdf", freqUnit.Label);
            Assert.AreEqual(7755, freqUnit.Value);
        }
    }
}
