using Models.Interfaces;
using SimpleInjector;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Attributes;

namespace ConsoleApp6
{
    public class GenericFactory<T> : IGenericFactory<T> where T: class
    {
        private Container container = null;

        public GenericFactory(Container container)
        {
            this.container = container;
        }

        public T CreateInstance()
        {
            return container.GetInstance<T>();
        }
    }
}
