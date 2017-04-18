using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ToolController : IToolController
    {
        private IEnumerable<ITool> tools = null;
        private Func<string, ITool> toolFactory = null;

        public ToolController(IEnumerable<ITool> tools, Func<string, ITool> toolFactory)
        {
            this.tools = tools;
            this.toolFactory = toolFactory;
        }

        public void PrintToolTypes()
        {
            Console.WriteLine("Available tool types :");
            foreach (ITool tool in tools)
            {
                Console.WriteLine($"- {tool.Type}");
            }
            Console.WriteLine();
        }

        public ITool CreateToolOfType(string toolType)
        {
            return toolFactory.Invoke(toolType);
        }
    }
}
