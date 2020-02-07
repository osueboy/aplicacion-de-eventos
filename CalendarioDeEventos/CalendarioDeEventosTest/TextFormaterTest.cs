using CalendarioDeEventos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CalendarioDeEventosTest
{
    [TestClass]
    public class TextFormaterTest
    {
        private TextFormater _textFormater;
        private Mock<ITimeChecker> _timeCheckerMock;
        private Mock<ITimeValueManager> _timeValueManager;

        [TestInitialize]
        public void OnSetup()        
        {

            _timeCheckerMock = new Mock<ITimeChecker>();
            _timeValueManager = new Mock<ITimeValueManager>();
            _textFormater = new TextFormater(_timeCheckerMock.Object, _timeValueManager.Object);
        }

        [TestMethod]
        public void FormatText_Method_should_return_future_template()
        {
            //Arrange
            SetValues(out string range, out int value, out string text);

            //Act
            _timeCheckerMock.Setup(x => x.CheckTime(It.IsAny<DateTime>())).Returns(new TimeCheckerResponse() { Past = false, TimePast = new TimeSpan() });
            _timeValueManager.Setup(x => x.GetTimeValue(It.IsAny<TimeSpan>())).Returns(new TimeValueResponse() { DateRange = range, Value = value });
            //Assert
            string formatedText = _textFormater.FormatText(text);
            Assert.AreEqual(string.Format(TextFormater.FutureTemplate, text.Split(",")[0], value, range), formatedText);
        }

        [TestMethod]
        public void FormatText_Method_should_return_past_template()
        {
            //Arrange
            SetValues(out string range, out int value, out string text);

            //Act
            _timeCheckerMock.Setup(x => x.CheckTime(It.IsAny<DateTime>())).Returns(new TimeCheckerResponse() { Past = true, TimePast = new TimeSpan() });
            _timeValueManager.Setup(x => x.GetTimeValue(It.IsAny<TimeSpan>())).Returns(new TimeValueResponse() { DateRange = range, Value = value });
            //Assert
            string formatedText = _textFormater.FormatText(text);
            Assert.AreEqual(string.Format(TextFormater.PastTemplate, text.Split(",")[0], value, range), formatedText);
        }
        private static void SetValues(out string range, out int value, out string text)
        {
            range = DateRanges.Months;
            value = 11;
            text = "Navidad 2020, 25/12/2020 00:00:00";
        }
    }
}
