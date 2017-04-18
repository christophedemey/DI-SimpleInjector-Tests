using Logger;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DirectoryStructureController : IDirectoryStructureController
    {
        private ILogger loggerValue = null;

        public DirectoryStructureController(ILogger logger)
        {
            loggerValue = logger;
        }

        public void CreateDirectoryStructure(IDataAccessController dataAccess)
        {
            Directory.CreateDirectory(Path.Combine(dataAccess.WorkingDirectory, "Configuration"));
            Directory.CreateDirectory(Path.Combine(dataAccess.WorkingDirectory, "Stations"));
            Directory.CreateDirectory(Path.Combine(dataAccess.WorkingDirectory, "License"));
        }
    }
}
