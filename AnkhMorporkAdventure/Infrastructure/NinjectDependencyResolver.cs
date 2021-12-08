using AnkhMorporkAdventure.Domain;
using Ninject;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
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
            
            kernel.Bind<IAssassinsRepo>().To<AssassinsRepo>()
                .WithConstructorArgument("context", dbContext);

            kernel.Bind<IThievesRepo>().To<ThievesRepo>()
                .WithConstructorArgument("context", dbContext);

            kernel.Bind<IBeggarsRepo>().To<BeggarsRepo>()
               .WithConstructorArgument("context", dbContext);

            kernel.Bind<IFoolsRepo>().To<FoolsRepo>()
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