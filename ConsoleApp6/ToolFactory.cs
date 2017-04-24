using Models.Interfaces;
using SimpleInjector;
using System.Linq;

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
               Where(row => row.Name == name).
               FirstOrDefault();
        }
    }
}
