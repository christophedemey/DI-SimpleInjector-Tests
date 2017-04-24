using Models.Interfaces;
using SimpleInjector;

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
