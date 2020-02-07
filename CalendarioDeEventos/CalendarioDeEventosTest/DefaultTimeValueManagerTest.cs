using CalendarioDeEventos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CalendarioDeEventosTest
{
    [TestClass]
    public class DefaultTimeValueManagerTest
    {

        private DefaultTimeValueManager _defaultTimeValueManager;
        private Mock<IRangeManager> _rangeManager;
        [TestInitialize]
        public void OnSetup()
        {
            _rangeManager = new Mock<IRangeManager>();
            _defaultTimeValueManager = new DefaultTimeValueManager(_rangeManager.Object);
        
        }
        [TestMethod]
        public void GetTimeValue_Method_should_return_the_month_range_when_more_than_30_days()
        {
            //Arrange
            //50 días
            TimeSpan time = new TimeSpan(50, 0, 0, 0, 0);
            _rangeManager.Setup(x => x.GetRange(It.IsAny<TimeSpan>())).Returns(DateRanges.Months);

            //Act
            TimeValueResponse response = _defaultTimeValueManager.GetTimeValue(time);
            //Assert
            Assert.AreEqual(DateRanges.Months, response.DateRange);
        }
        [TestMethod]
        public void GetTimeValue_Method_should_return_days_time_value()
        {
            //Arrange
            //50 días
            TimeSpan time = new TimeSpan(50, 0, 0, 0, 0);
            _rangeManager.Setup(x => x.GetRange(It.IsAny<TimeSpan>())).Returns(DateRanges.Months);
            //Act
            TimeValueResponse response = _defaultTimeValueManager.GetTimeValue(time);
            //Assert
            Assert.AreEqual((int)time.TotalDays / 30, response.Value);
        }


        [TestMethod]
        public void GetTimeValue_Method_should_return_the_day_range_when_more_than_one_day_but_less_than_30()
        {
            //Arrange
            //5 días
            TimeSpan time = new TimeSpan(5, 0, 0, 0, 0);
            _rangeManager.Setup(x => x.GetRange(It.IsAny<TimeSpan>())).Returns(DateRanges.Days);
            //Act
            TimeValueResponse response = _defaultTimeValueManager.GetTimeValue(time);
            //Assert
            Assert.AreEqual(DateRanges.Days, response.DateRange);
        }

        [TestMethod]
        public void GetTimeValue_Method_should_return_the_day_range_when_more_than_one_hour_but_less_than_24()
        {
            //Arrange
            //20 horas
            TimeSpan time = new TimeSpan(0, 20, 0, 0, 0);
            _rangeManager.Setup(x => x.GetRange(It.IsAny<TimeSpan>())).Returns(DateRanges.Hours);
            //Act
            TimeValueResponse response = _defaultTimeValueManager.GetTimeValue(time);
            //Assert
            Assert.AreEqual(DateRanges.Hours, response.DateRange);
        }

        [TestMethod]
        public void GetTimeValue_Method_should_return_the_day_range_when_less_than_60_minutes()
        {
            //Arrange
            //20 horas
            TimeSpan time = new TimeSpan(0, 0, 40, 0, 0);
            _rangeManager.Setup(x => x.GetRange(It.IsAny<TimeSpan>())).Returns(DateRanges.Minutes);
            //Act
            TimeValueResponse response = _defaultTimeValueManager.GetTimeValue(time);
            //Assert
            Assert.AreEqual(DateRanges.Minutes, response.DateRange);
        }

        [TestMethod]
        public void GetTimeValue_Method_throws_if_range_is_not_found()
        {
            //Arrange
            string range = "badRange";
            TimeSpan time = new TimeSpan(0, 0, 40, 0, 0);

            _rangeManager.Setup(x => x.GetRange(It.IsAny<TimeSpan>())).Returns(range);

            //Act - Assert
            Exception exception = Assert.ThrowsException<Exception>( () => _defaultTimeValueManager.GetTimeValue(time) );
        }
    }
}
