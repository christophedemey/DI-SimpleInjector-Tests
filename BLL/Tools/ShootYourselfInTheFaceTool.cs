using Models.Interfaces;
using System;
using System.Reflection;

namespace BLL.Tools
{
    public class ShootYourselfInTheFaceTool : ITool
    {
        public ShootYourselfInTheFaceTool()
        {
            Console.WriteLine($"{Name} tool created.");
        }

        public string Name => "Shoot Yourself In The Face Tool";

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
