using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BLL
{
    public class ToolController : IToolController
    {
        private IEnumerable<ITool> tools = null;
        private IToolFactory toolFactory = null;

        public ToolController(IToolFactory toolFactory)
        {
            this.toolFactory = toolFactory;
            this.tools = toolFactory.CreateAllTools();
        }

        public void PrintToolTypes()
        {
            Console.WriteLine("\r\nListing Available tool types :");
            foreach (ITool tool in tools)
            {
                Console.WriteLine($"- {tool.Name}");
            }
            Console.WriteLine();
        }

        public ITool CreateToolOfType(string toolType)
        {
            return toolFactory.CreateInstance(toolType);
        }

        public List<string> GetToolTypes()
        {
            List<string> toolTypes = new List<string>();
            foreach (ITool tool in tools)
            {
                toolTypes.Add(tool.Name);
            }
            return toolTypes;
        }
    }
}
