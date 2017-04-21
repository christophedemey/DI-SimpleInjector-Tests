using Models.Interfaces;
using System;
using Models.Attributes;
using System.Reflection;

namespace BLL.Tools
{
    [ToolName("Woooooop Tool")]
    public class WoopTool : ITool
    {
        public void Disable()
        {
            Console.WriteLine($"Disabled {GetType().GetCustomAttribute<ToolNameAttribute>().Name}");
        }

        public void Enable()
        {
            Console.WriteLine($"Enabled {GetType().GetCustomAttribute<ToolNameAttribute>().Name}");
        }
    }
}
