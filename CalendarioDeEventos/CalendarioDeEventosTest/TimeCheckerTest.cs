using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CalendarioDeEventos.Tests
{
    [TestClass]
    public class TimeCheckerTest
    {
        private TimeChecker _timeChecker;
        private Mock<IClockReader> _clockReader;
        [TestInitialize]
        public void OnSetup()
        {
            _clockReader = new Mock<IClockReader>();
            _timeChecker = new TimeChecker(_clockReader.Object);

        }

        [TestMethod]
        public void CheckTime_Method_should_return_past_false_when_date_is_in_the_future()
        {
            //Arrange
            _clockReader.Setup(x => x.CurrentTime()).Returns(new DateTime(2020, 02, 01));
            DateTime dateToVerify = new DateTime(2021, 01, 01, 12, 00, 00);
            //Act
            TimeCheckerResponse response = _timeChecker.CheckTime(dateToVerify);
            //Assert
            Assert.IsFalse(response.Past);
        }

        [TestMethod]
        public void CheckTime_Method_should_return_past_true_when_date_is_in_the_past()
        {
            //Arrange
            _clockReader.Setup(x => x.CurrentTime()).Returns(new DateTime(2020, 02, 01));
            DateTime dateToVerify = new DateTime(2019, 01, 01, 12, 00, 00);
            //Act
            TimeCheckerResponse response = _timeChecker.CheckTime(dateToVerify);
            //Assert
            Assert.IsTrue(response.Past);
        }

        [TestMethod]
        public void CheckTime_Method_should_return_past_false_when_date_equal()
        {
            //Arrange
            DateTime sameDate = DateTime.Now;
            _clockReader.Setup(x => x.CurrentTime()).Returns(sameDate);
            //Act
            TimeCheckerResponse response = _timeChecker.CheckTime(sameDate);
            //Assert
            Assert.IsFalse(response.Past);
        }

        [TestMethod]
        public void CheckTime_Method_should_return_timespan_with_absolute_diference_between_times()
        {
            //Arrange
            DateTime pastDate = DateTime.Now;
            int days = 60;
            DateTime futureDate = pastDate.AddDays(days);
            _clockReader.Setup(x => x.CurrentTime()).Returns(futureDate);
            //Act
            TimeCheckerResponse response = _timeChecker.CheckTime(pastDate);
            //Assert
            Assert.AreEqual(response.TimePast, new TimeSpan(days,0,0,0,0));
        }
    }
}