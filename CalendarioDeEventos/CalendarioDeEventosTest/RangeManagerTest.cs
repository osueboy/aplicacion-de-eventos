using CalendarioDeEventos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalendarioDeEventosTest
{
    [TestClass]
    public class RangeManagerTest
    {
        private RangeManager _rangeManager;

        [TestInitialize]
        public void OnSetup()
        {
            _rangeManager = new RangeManager();
        }

        [TestMethod]
        [DataRow(60)]
        [DataRow(30)]
        public void GetRange_Method_should_return_month_range(int days)
        {
            //Arrange
            TimeSpan timeSpan = new TimeSpan(days, 0, 0, 0, 0);
            //Act
            string range = _rangeManager.GetRange(timeSpan);
            //Assert
            Assert.AreEqual(DateRanges.Months, range);
        }
        [TestMethod]
        [DataRow(29)]
        [DataRow(1)]
        public void GetRange_Method_should_return_days_range(int days)
        {
            //Arrange
            TimeSpan timeSpan = new TimeSpan(days, 0, 0, 0, 0);
            //Act
            string range = _rangeManager.GetRange(timeSpan);
            //Assert
            Assert.AreEqual(DateRanges.Days, range);
        }
        [TestMethod]
        [DataRow(23)]
        [DataRow(1)]
        public void GetRange_Method_should_return_hours_range(int hours)
        {
            //Arrange
            TimeSpan timeSpan = new TimeSpan(0, hours, 0, 0, 0);
            //Act
            string range = _rangeManager.GetRange(timeSpan);
            //Assert
            Assert.AreEqual(DateRanges.Hours, range);
        }
        [TestMethod]
        [DataRow(59)]
        [DataRow(1)]
        public void GetRange_Method_should_return_minutes_range(int minutes)
        {
            //Arrange
            TimeSpan timeSpan = new TimeSpan(0, 0, minutes, 0, 0);
            //Act
            string range = _rangeManager.GetRange(timeSpan);
            //Assert
            Assert.AreEqual(DateRanges.Minutes, range);
        }
    }
}
