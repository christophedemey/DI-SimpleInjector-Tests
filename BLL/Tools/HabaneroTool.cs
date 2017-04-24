using Models.Interfaces;
using System;

namespace BLL.Tools
{
    public class HabaneroTool : ITool
    {
        public HabaneroTool()
        {
            Console.WriteLine($"{Name} tool created.");
        }

        public string Name => "Habanero Tool";

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
