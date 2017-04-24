using Models.Interfaces;
using System;
using System.Reflection;

namespace BLL.Tools
{
    public class WoopTool : ITool
    {
        public WoopTool()
        {
            Console.WriteLine($"{Name} tool created.");
        }

        public string Name => "Woop Tool";

        public void Disable()
        {
            Console.WriteLine($"Disabled {Name}");
        }

        public void Enable()
        {
            Console.WriteLine($"Enabled {Name}");
        }
    }
}
