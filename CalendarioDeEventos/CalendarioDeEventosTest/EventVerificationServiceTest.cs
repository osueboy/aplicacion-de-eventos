using CalendarioDeEventos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace CalendarioDeEventosTest
{
    [TestClass]
    public class EventVerificationServiceTest
    {
        private EventVerificationService _eventVerificationService;
        private Mock<ITextFileReader> _textFileReader;
        private Mock<IPrinter> _printer;
        [TestInitialize]
        public void OnSetup()
        {
            _textFileReader = new Mock<ITextFileReader>();
            _printer = new Mock<IPrinter>();
            _eventVerificationService = new EventVerificationService(_textFileReader.Object, _printer.Object);
            _textFileReader.Setup(x => x.ReadLines(It.IsAny<string>())).Returns(new List<string>() { "texto evento 1", "texto evento 2" });
        }

        [TestMethod]
        public void GetAllEvents_should_call_file_reader_with_path()
        {
            //Arrange
            string pathToFile = "path/string.txt";
            //Act
            _eventVerificationService.GetAllEvents(pathToFile);
            //Assert
            _textFileReader.Verify(x => x.ReadLines(pathToFile), Times.Once);
        }
        [TestMethod]
        public void GetAllEvents_should_call_printer_for_every_line_obtained()
        {
            //Arrange
            string pathToFile = "path/string.txt";
            //Act
            _eventVerificationService.GetAllEvents(pathToFile);
            //Assert
            _printer.Verify(x => x.PrintText(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
