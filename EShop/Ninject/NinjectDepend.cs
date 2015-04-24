using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using System.Configuration;
using EShop.SQL_Rep;

namespace EShop.Ninject
{
    public class NinjectDepend : IDependencyResolver
    {


        private IKernel kernel;
        public NinjectDepend()
        {
            kernel = new StandardKernel();
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
            kernel.Bind<IReposit>().To<TestSQL>();
        }

    }
}