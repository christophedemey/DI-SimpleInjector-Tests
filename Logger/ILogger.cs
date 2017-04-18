using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface ILogger
    {
        void Initialize(string workingDirectory);
        void Execute();
        void WriteLine(string logFile, string data);
    }
}
