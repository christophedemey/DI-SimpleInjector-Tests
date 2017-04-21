using Models.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class FactoryController<T> : IFactory<T> where T: class
    {
        private Container container = null;

        public FactoryController(Container container)
        {
            this.container = container;
        }

        public T CreateInstance()
        {
            return container.GetInstance<T>();
        }
    }
}
