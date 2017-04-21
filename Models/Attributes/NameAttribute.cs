using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Attributes
{
    public class ToolNameAttribute : Attribute
    {
        public readonly string Name;
        public ToolNameAttribute(string name) { Name = name; }
    }
}
