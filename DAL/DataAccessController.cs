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
    public class DataAccessController : IDataAccessController
    {
        private ILogger logger = null;
        private IDirectoryStructureController directoryStructureController = null;

        public string WorkingDirectory { get; set; }

        public DataAccessController(ILogger logger, IDirectoryStructureController directoryStructureController)
        {
            this.logger = logger;
            this.directoryStructureController = directoryStructureController;
        }

        public void InitializeLogger()
        {
            this.logger.Initialize(WorkingDirectory);
            this.logger.Execute();
        }
  
        public void SetWorkingDirectory()
        {
            WorkingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"De Jaeger Automation\Test-App");
        }
        
        public void CreateDirectoryStructure()
        {
            directoryStructureController.CreateDirectoryStructure(this);
            directoryStructureController = null;
        }
    }
}
