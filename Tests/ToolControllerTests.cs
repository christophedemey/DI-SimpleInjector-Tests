using BLL;
using BLL.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class ToolControllerTests
    {
        private IToolController toolController = null;

        [TestInitialize]
        public void TestInitialize()
        {
            List<ITool> tools = new List<ITool>();

            for (int i = 0; i < 10; i++)
            {
                Mock<ITool> tool = new Mock<ITool>();
                tool.Setup(row => row.Name).Returns($"Tool {i}");
                tools.Add(tool.Object);
            }

            Mock<IToolFactory> toolFactory = new Mock<IToolFactory>();
            toolFactory.Setup(row => row.CreateInstance(It.IsAny<string>())).Returns(new AmazingTool());

            toolController = new ToolController(tools, toolFactory.Object);
        }

        [TestMethod]
        public void ShouldReturnToolTypes()
        {
            List<string> toolTypes = toolController.GetToolTypes();
            Assert.IsTrue(toolTypes.Count == 10);
            Assert.IsTrue(toolTypes[5] == "Tool 5");
        }

        [TestMethod]
        public void ShouldReturnAmazingToolImplementation()
        {
            ITool tool = toolController.CreateToolOfType("Amazing Tool");
            Assert.IsTrue(tool is AmazingTool);
        }
    }
}
