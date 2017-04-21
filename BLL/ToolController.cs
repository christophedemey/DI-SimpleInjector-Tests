using BLL.Tools;
using Models.Attributes;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ToolController : IToolController
    {
        private IEnumerable<ITool> tools = null;
        private IToolFactory toolFactory = null;

        public ToolController(IEnumerable<ITool> tools, IToolFactory toolFactory)
        {
            this.tools = tools;
            this.toolFactory = toolFactory;
        }

        public void PrintToolTypes()
        {
            Console.WriteLine("Available tool types :");
            foreach (ITool tool in tools)
            {
                Console.WriteLine($"- {tool.GetType().GetCustomAttribute<ToolNameAttribute>().Name}");
            }
            Console.WriteLine();
        }

        public ITool CreateToolOfType(string toolType)
        {
            return toolFactory.CreateInstance(toolType);
        }
    }
}
