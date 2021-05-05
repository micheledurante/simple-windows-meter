﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Units;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class PercentUnitTest
    {
        [TestMethod]
        public void Ctor_Default_ShouldCreateBaseWithExpectedProperties()
        {
            var percentUnit = new PercentUnit("sda", "asd", 999);

            Assert.AreEqual(PercentUnit.DefaultMeasurementUnit, percentUnit.measurementUnit);
            Assert.AreEqual(PercentUnit.DefaultFormat, percentUnit.numberFormat);
            Assert.AreEqual("asd", percentUnit.Label);
            Assert.AreEqual(999, percentUnit.Value);
        }
    }
}
