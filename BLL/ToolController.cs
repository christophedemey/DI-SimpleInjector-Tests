using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BLL
{
    public class ToolController : IToolController
    {
        private IEnumerable<ITool> tools = null;
        private Func<List<ITool>> toolFactory = null;
        private Func<string, ITool> toolInstanceFactory = null;

        public ToolController(Func<List<ITool>> toolFactory, Func<string, ITool> toolInstanceFactory)
        {
            this.toolFactory = toolFactory;
            this.toolInstanceFactory = toolInstanceFactory;
        }

        public void PrintToolTypes()
        {
            Console.WriteLine("\r\nListing Available tool types :");
            foreach (ITool tool in toolFactory.Invoke())
            {
                Console.WriteLine($"- {tool.Name}");
            }
            Console.WriteLine();
        }

        public ITool CreateToolOfType(string toolType)
        {
            return toolInstanceFactory.Invoke(toolType);
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
