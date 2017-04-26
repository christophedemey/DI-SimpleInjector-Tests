using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IToolFactory
    {
        List<ITool> CreateAllTools();
        ITool CreateInstance(string name);
    }
}