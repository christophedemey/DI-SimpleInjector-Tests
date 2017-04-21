using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using Models.Interfaces;
using Moq;
using Logger;

namespace Tests
{
    [TestClass]
    public class BussinesLogicControllerTests
    {
        private Mock<IDataAccessController> dataAccess = null;
        private Mock<ILogger> logger = null;
        private Mock<IToolController> tools = null;
        private Mock<IFactory<IStationController>> stationFactory = null;
        private IBussinesLogicController bussinesLogic = null;

        [TestInitialize]
        public void TestInitialize()
        {
            dataAccess = new Mock<IDataAccessController>();
            logger = new Mock<ILogger>();
            tools = new Mock<IToolController>();
            stationFactory = new Mock<IFactory<IStationController>>();

            bussinesLogic = new BussinesLogicController(dataAccess.Object, logger.Object, stationFactory.Object);
            bussinesLogic.ToolController = tools.Object;
        }

        [TestMethod]
        public void ShouldCallMethods()
        {
            // Arrange : Done in TestInitialize()

            // Act : Call bussines logic execute.
            bussinesLogic.Execute();

            //Assert : Verify functions are being called by concrete BussinesLogicController implementation.
            logger.Verify(row => row.WriteLine("Debug", "Executing BussinesLogic..."), Times.Once);
            dataAccess.Verify(row => row.SetWorkingDirectory(), Times.Once);
            dataAccess.Verify(row => row.InitializeLogger(), Times.Once);
            dataAccess.Verify(row => row.CreateDirectoryStructure(), Times.Once);
            tools.Verify(row => row.PrintToolTypes(), Times.Once);
        }

        [TestMethod]
        public void ShouldNotCatchLoggerWriteLineException()
        {
            // Arrange : dataAccess.CreateDirectoryStructure() throws Exception.
            logger.Setup(row => row.WriteLine(It.IsAny<string>(), It.IsAny<string>())).Throws<Exception>();

            // Act-Assert : Call bussines logic execute.
            Assert.ThrowsException<Exception>(() => bussinesLogic.Execute());
        }

        [TestMethod]
        public void ShouldNotCatchCreateDirectoryStructureException()
        {
            // Arrange : dataAccess.CreateDirectoryStructure() throws Exception.
            dataAccess.Setup(row => row.CreateDirectoryStructure()).Throws<Exception>();

            // Act-Assert : Call bussines logic execute.
            Assert.ThrowsException<Exception>(() => bussinesLogic.Execute());
        }

        [TestMethod]
        public void ShouldNotCatchSetWorkingDirectoryException()
        {
            // Arrange : dataAccess.CreateDirectoryStructure() throws Exception.
            dataAccess.Setup(row => row.SetWorkingDirectory()).Throws<Exception>();

            // Act-Assert : Call bussines logic execute.
            Assert.ThrowsException<Exception>(() => bussinesLogic.Execute());
        }

        [TestMethod]
        public void ShouldNotCatchPrintToolTypesException()
        {
            // Arrange : dataAccess.CreateDirectoryStructure() throws Exception.
            tools.Setup(row => row.PrintToolTypes()).Throws<Exception>();

            // Act-Assert : Call bussines logic execute.
            Assert.ThrowsException<Exception>(() => bussinesLogic.Execute());
        }

        private IStationController StationFactory()
        {
            return null;
        }
    }
}
