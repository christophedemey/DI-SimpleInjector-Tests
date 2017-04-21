using Logger;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BussinesLogicController : IBussinesLogicController
    {
        private IDataAccessController dataAccess = null;
        private ILogger logger = null;
        private IFactory<IStationController> stationControllerFactory = null;
        public IToolController ToolController { get; set; }

        public BussinesLogicController(IDataAccessController dataAccess,
            ILogger logger,
          IFactory<IStationController> stationControllerFactory)
        {
            this.dataAccess = dataAccess;
            this.logger = logger;
            this.stationControllerFactory = stationControllerFactory;
        }

        public void Execute()
        {
            logger.WriteLine("Debug", "Executing BussinesLogic...");
            dataAccess.SetWorkingDirectory();
            dataAccess.InitializeLogger();
            dataAccess.CreateDirectoryStructure();

            ToolController.PrintToolTypes();

            List<ITool> amazingTools = new List<ITool>();
            for (int i = 0; i < 1000000; i++)
            {
                amazingTools.Add(ToolController.CreateToolOfType("AmazingTool"));
            }
        }
    }
}
