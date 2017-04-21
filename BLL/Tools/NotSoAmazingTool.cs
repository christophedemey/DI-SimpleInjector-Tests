using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tools
{
    [Name("Not So Amazing Tool")]
    public class NotSoAmazingTool : ITool
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
