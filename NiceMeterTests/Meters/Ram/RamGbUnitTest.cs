using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceMeter.Meters.Ram;
using System.Globalization;

namespace NiceMeterTests.Meters.Ram
{
    [TestClass]
    public class RamGbUnitTest
    {
        [TestMethod]
        public void ToString_GivenCulture_ShouldOverrideAndFormatWithThreadsCulture()
        {
            var ramGbUnit = new RamGbUnit("qwerty", "asdf", 13.63898F);

            var culture = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Assert.AreEqual("13,6 GB", ramGbUnit.ToString());
        }
    }
}
