using BLL;
using BLL.Tools;
using DAL;
using Logger;
using Models.Interfaces;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = ComposeRoot();

            IBussinesLogicController controller = container.GetInstance<IBussinesLogicController>();
            controller.Execute();

            Console.WriteLine("\r\nRequesting instance of ITool with name Amazing Tool");
            ITool toolTest = controller.ToolController.CreateToolOfType("Amazing Tool");
            Console.WriteLine($"Instance of {toolTest.Name} resolved.");

            Console.WriteLine("\r\nStarted");
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

            //Register all tools which reside in the same assembly as the concrete AmazingTool implementation.
            var toolAssembly = typeof(AmazingTool).Assembly;
            Assembly[] assemblies = new Assembly[] { toolAssembly };
            container.RegisterCollection(typeof(ITool), new List<Assembly> { toolAssembly });

            //Register tool controller.
            container.Register<IToolController, ToolController>(Lifestyle.Singleton);

            //Register tool factory.
            container.RegisterSingleton<IToolFactory, ToolFactory>();

            //Data Access controllers.
            container.Register<IDataAccessController, DataAccessController>(Lifestyle.Singleton);
            container.Register<IDirectoryStructureController, DirectoryStructureController>(Lifestyle.Singleton);

            //Shared controllers.
            container.Register<ILogger, LoggerController>(Lifestyle.Singleton);

            //Generic factory.
            container.Register(typeof(IGenericFactory<>), typeof(GenericFactory<>), Lifestyle.Singleton);


            container.Verify();

            return container;
        }
    }
}
