using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Meters;
using NiceMeter.Meters.Units;
using System.Collections.Generic;

namespace NiceMeterTests.Meters
{
    [TestClass]
    public class AbstractMeterTest
    {
        [TestMethod]
        public void FormatUnits_EmptyUnitsList_ShouldReturnEmptyString()
        {
            var meterMock = new MeterMock();

            var formatUnits = meterMock.FormatUnits(new List<IUnit>());

            Assert.AreEqual("", formatUnits);
        }

        [TestMethod]
        public void FormatUnits_SinlgeUnitInList_ShouldReturnTheUnitToString()
        {
            var meterMock = new MeterMock();
            var unitToString = new Faker().Random.Word();
            var unitMock = new Mock<IUnit>();
            unitMock.Setup(x => x.ToString()).Returns(unitToString);
            var units = new List<IUnit>();

            units.Add(unitMock.Object);
            var formatUnits = meterMock.FormatUnits(units);

            unitMock.Verify(x => x.ToString(), Times.Once);
            Assert.AreEqual(unitToString, formatUnits);
        }

        [TestMethod]
        public void FormatUnits_MultipleUnitsInList_ShouldReturnTheUnitsToStringJoinedByTheUnitsSeparator()
        {
            var meterMock = new MeterMock();
            var unit1ToString = new Faker().Random.Word();
            var unit2ToString = new Faker().Random.Word();
            var unitMock1 = new Mock<IUnit>();  
            unitMock1.Setup(x => x.ToString()).Returns(unit1ToString);
            var unitMock2 = new Mock<IUnit>();
            unitMock2.Setup(x => x.ToString()).Returns(unit2ToString);
            var units = new List<IUnit>();

            units.Add(unitMock1.Object);
            units.Add(unitMock2.Object);
            var formatUnits = meterMock.FormatUnits(units);

            unitMock1.Verify(x => x.ToString(), Times.Once);
            unitMock2.Verify(x => x.ToString(), Times.Once);
            Assert.AreEqual(string.Join(AbstractMeter.UNITS_SEPARATOR, unit1ToString, unit2ToString), formatUnits);
        }
    }
}
