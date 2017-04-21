using Models.Attributes;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tools
{
    [ToolName("Not So Amazing Tool")]
    public class NotSoAmazingTool : ITool
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
