using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using SOneApprendaHelper.Services;

namespace SOneApprendaHelper.Core
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public DependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            addBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void addBindings()
        {
            _kernel.Bind<ICookiesService>().To<CookiesService>().InSingletonScope();
            _kernel.Bind<ITextGenerator>().To<TextGenerator>().InSingletonScope();
            _kernel.Bind<IApprendaLinksGenerator>().To<ApprendaLinksGenerator>().InSingletonScope();
        }
    }
}