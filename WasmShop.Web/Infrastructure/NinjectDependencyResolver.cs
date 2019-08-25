using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WasmShop.Data.Infrastructure;
using WasmShop.Data.Repositories;
using Ninject.Extensions.Conventions;
using WasmShop.Service;

namespace WasmShop.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IDbFactory>().To<DbFactory>();

            kernel.Bind(x => x.FromAssembliesMatching("WasmShop.Service.dll")
                    .SelectAllClasses()
                    .BindAllInterfaces()
            );

            //kernel.Bind<IProductCategoryService>().To<ProductCategoryService>();
            kernel.Bind<IProductCategoryRepository>().To<ProductCategoryRepository>();
        }
    }
}