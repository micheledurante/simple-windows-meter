using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Ram;
using System.Globalization;

namespace NiceMeterTests.Meters.Units
{
    [TestClass]
    public class RamPercentUnitTest
    {
        [TestMethod]
        public void ToString_GivenCulture_ShouldOverrideAndFormatWithThreadsCulture()
        {
            var ramPercentUnit = new RamPercentUnit("dsa", "zxcv", 12316);

            var culture = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Assert.AreEqual("12.316,0 %", ramPercentUnit.ToString());
        }
    }
}
