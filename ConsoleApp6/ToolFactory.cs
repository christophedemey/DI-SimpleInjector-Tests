using Models.Attributes;
using Models.Interfaces;
using SimpleInjector;
using System.Linq;
using System.Reflection;

namespace ConsoleApp6
{
    public class ToolFactory : IToolFactory
    {
        private Container container = null;

        public ToolFactory(Container container)
        {
            this.container = container;
        }
      
        public ITool CreateInstance(string name)
        {
            return container.GetAllInstances<ITool>().
               Where(row => row.GetType().GetCustomAttribute<ToolNameAttribute>().Name == name).
               FirstOrDefault();
        }
    }
}
