using CalendarioDeEventos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalendarioDeEventosTest
{
    [TestClass]
    public class ConsolePrinterTest
    {
        private ConsolePrinter _consolePrinter;
        private Mock<ITextFormater> _textFormaterMock;
        [TestInitialize]
        public void OnSetup()
        {
            _textFormaterMock = new Mock<ITextFormater>();
            _consolePrinter = new ConsolePrinter(_textFormaterMock.Object);
        }

        [TestMethod]
        public void PrintText_Method_should_call_formater()
        {
            //Arrange
            string text = "TextEvent, 01/01/2020 00:00:00";
            //Act
            _consolePrinter.PrintText(text);
            //Assert
            _textFormaterMock.Verify(x => x.FormatText(text), Times.Once);
        }
    }
}
