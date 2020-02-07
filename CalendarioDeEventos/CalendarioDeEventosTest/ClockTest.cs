using CalendarioDeEventos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalendarioDeEventosTest
{
    [TestClass]
    public class ClockTest
    {
        [TestMethod]
        public void GetCurrentTime_returns_a_date()
        {
            //Arrange
            IClockReader clock = new Clock();
            DateTime dateTime = clock.CurrentTime();
            Assert.IsNotNull(dateTime);
        }
    }
}
