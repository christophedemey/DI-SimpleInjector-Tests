using Models.Interfaces;
using System;
using Models.Attributes;

namespace BLL.Tools
{
    [ToolName("Woooooop Tool")]
    public class WoopTool : ITool
    {
        public string Name => this.GetType().Name;

        public void Disable()
        {
            Console.WriteLine($"Disabled {Name.ToString()}");
        }

        public void Enable()
        {
            Console.WriteLine($"Enabled {Name.ToString()}");
        }
    }
}
