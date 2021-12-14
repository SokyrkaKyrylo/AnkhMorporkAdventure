using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            var dbContext = ApplicationContext.GetInstance();

            kernel.Bind<IAssassinsRepo>().To<AssassinsRepo>().InSingletonScope()
                .WithConstructorArgument("context", dbContext);

            kernel.Bind<IThievesRepo>().To<ThievesRepo>().InSingletonScope()
                .WithConstructorArgument("context", dbContext);

            kernel.Bind<IBeggarsRepo>().To<BeggarsRepo>().InSingletonScope()
               .WithConstructorArgument("context", dbContext);

            kernel.Bind<IFoolsRepo>().To<FoolsRepo>().InSingletonScope()
               .WithConstructorArgument("context", dbContext);

            kernel.Bind<IItemsRepo>().To<ItemsRepo>().InSingletonScope()
               .WithConstructorArgument("context", dbContext);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}