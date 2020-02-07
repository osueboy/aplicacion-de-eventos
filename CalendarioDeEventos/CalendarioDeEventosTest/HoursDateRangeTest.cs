using CalendarioDeEventos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalendarioDeEventosTest
{
    [TestClass]
    public class HoursDateRangeTest
    {
        private HoursDateRange _hoursDateRange;
        [TestInitialize]
        public void OnSetup()
        {
            _hoursDateRange = new HoursDateRange();
        }
        [TestMethod]
        public void Range_Property_should_return_date_ranges_equal_hours()
        {
            //Act
            string range = _hoursDateRange.Range;
            //Assert
            Assert.IsTrue(range == DateRanges.Hours);
        }
        [TestMethod]
        [DataRow(60)]
        [DataRow(61)]
        public void Validate_Method_should_return_true_when_timespan_minutes_are_greater_than_or_equal_60(int minutes)
        {
            //Arrange
            TimeSpan timeSpan = new TimeSpan(0, minutes, 0);
            //Act
            bool validateResult = _hoursDateRange.Validate(timeSpan);
            //Assert
            Assert.IsTrue(validateResult);
        }
        [TestMethod]
        public void Validate_Method_should_return_false_when_timespan_minutes_are_lower_than_60()
        {
            //Arrange
            TimeSpan timeSpan = new TimeSpan(0, 59, 0);
            //Act
            bool validateResult = _hoursDateRange.Validate(timeSpan);
            //Assert
            Assert.IsFalse(validateResult);
        }
    }
}
