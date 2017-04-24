using Models.Interfaces;
using System;

namespace BLL.Tools
{
    public class AmazingTool : ITool
    {
        public AmazingTool()
        {
            Console.WriteLine($"{Name} tool created.");
        }

        public string Name => "Amazing Tool";

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
