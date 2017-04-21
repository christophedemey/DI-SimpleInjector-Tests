using Models.Attributes;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BLL.Tools
{
    [ToolName("Amazing Tool")]
    public class AmazingTool : ITool
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
