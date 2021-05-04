using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class WattUnitTest
    {
        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var percentUnit = new WattUnit("ytrewq", 3443);

            Assert.AreEqual(WattUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(WattUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual("ytrewq", percentUnit.Label);
            Assert.AreEqual(3443, percentUnit.Value);
        }
    }
}
