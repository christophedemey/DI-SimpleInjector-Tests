using Models.Interfaces;
using System;
using System.Reflection;

namespace BLL.Tools
{
    public class NotSoAmazingTool : ITool
    {
        public NotSoAmazingTool()
        {
            Console.WriteLine($"{Name} tool created.");
        }

        public string Name => "Not So Amazing Tool";

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
