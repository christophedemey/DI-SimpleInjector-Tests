using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tools
{
    public class WoopTool : ITool
    {
        public string Type => this.GetType().Name;

        public void Disable()
        {
            Console.WriteLine($"Disabled {Type.ToString()}");
        }

        public void Enable()
        {
            Console.WriteLine($"Enabled {Type.ToString()}");
        }
    }
}
