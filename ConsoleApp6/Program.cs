using BLL;
using BLL.Tools;
using DAL;
using Logger;
using Models.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = ComposeRoot();

            IBussinesLogicController controller = container.GetInstance<IBussinesLogicController>();
            controller.Execute();

            Console.WriteLine("Started");
            Console.ReadLine();
        }

        private static Container ComposeRoot()
        {
            var container = new Container();

            //Bussines Logic controllers.
            container.Register<IBussinesLogicController, BussinesLogicController>(Lifestyle.Singleton);

            //Property injection on IBussinesLogicController.ToolController property.
            container.RegisterInitializer<IBussinesLogicController>(controller => controller.ToolController = container.GetInstance<IToolController>());

            //Register station controller.
            container.Register<IStationController, StationController>(Lifestyle.Transient);
            //Register station controller factory (for creating more stations).
            container.RegisterSingleton<Func<IStationController>>(() => container.GetInstance<IStationController>());

            //Register all tools which reside in the same assembly as the concrete AmazingTool implementation.
            var toolAssembly = typeof(AmazingTool).Assembly;
            Assembly[] assemblies = new Assembly[] { toolAssembly };
            container.RegisterCollection(typeof(ITool), new List<Assembly> { toolAssembly });

            //Register tool controller.
            container.Register<IToolController, ToolController>(Lifestyle.Singleton);

            //Register tool factory.
            container.RegisterSingleton<Func<string, ITool>>((toolType) => container.GetAllInstances<ITool>().Where(row => row.Type == toolType).FirstOrDefault());


            //Data Access controllers.
            container.Register<IDataAccessController, DataAccessController>(Lifestyle.Singleton);
            container.Register<IDirectoryStructureController, DirectoryStructureController>(Lifestyle.Singleton);

            //Shared controllers.
            container.Register<ILogger, LoggerController>(Lifestyle.Singleton);
            
            container.Verify();

            return container;
        }
    }
}
