using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface ITool
    {
        string Type { get;   }
        void Enable();
        void Disable();

    }
}
