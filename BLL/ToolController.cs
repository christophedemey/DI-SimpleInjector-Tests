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

        public ToolController(IEnumerable<ITool> tools, IToolFactory toolFactory)
        {
            Console.WriteLine("ToolController created - Gets injected IENumerable<ITool>.");

            this.tools = tools;
            this.toolFactory = toolFactory;
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
