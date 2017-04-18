using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class LoggerController : ILogger
    {
        private string workingDirectoryValue = string.Empty;

        public void Execute()
        {
            if (!Directory.Exists(workingDirectoryValue))
            {
                Directory.CreateDirectory(workingDirectoryValue);
            }
        }

        public void Initialize(string workingDirectory)
        {
            workingDirectoryValue = workingDirectory;
        }

        public void WriteLine(string logFile, string data)
        {
            StreamWriter writer = new StreamWriter(Path.Combine(workingDirectoryValue, $"{logFile}.txt"), true);
            writer.WriteLine(data);
            writer.Flush();
            writer.Close();
            writer.Dispose();
        }
    }
}
