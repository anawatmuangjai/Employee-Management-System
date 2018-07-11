using Ninject;
using Ninject.Modules;

namespace EMS.WinForm.IoCContainer
{
    public static class IoC
    {
        private static StandardKernel _kernel;

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static void Initialize(params INinjectModule[] ninjectModule)
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel(ninjectModule);
            }
        }
    }
}
