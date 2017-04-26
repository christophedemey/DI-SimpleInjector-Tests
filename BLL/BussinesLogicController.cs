using Logger;
using Models.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BussinesLogicController : IBussinesLogicController
    {
        private IDataAccessController dataAccess = null;
        private ILogger logger = null;
        private Func<Type, object> stationControllerFactory = null;
        public IToolController ToolController { get; set; }

        public BussinesLogicController(IDataAccessController dataAccess,
          ILogger logger,
          Func<Type, object> stationControllerFactory)
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

            var stationController = stationControllerFactory.Invoke(typeof(IStationController));

            //ITool toolTest = ToolController.CreateToolOfType("Amazing Tool");
            //toolTest.Enable();
            //toolTest.Disable();

            //List<ITool> amazingTools = new List<ITool>();
            //for (int i = 0; i < 100; i++)
            //{
            //    amazingTools.Add(ToolController.CreateToolOfType("Amazing Tool"));
            //}
        }
    }
}
