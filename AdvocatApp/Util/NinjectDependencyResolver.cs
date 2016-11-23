using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using AdvocatApp.BL.Authorization.Interfaces;
using AdvocatApp.BL.Authorization.Services;
using AdvocatApp.DAL.Interfaces;
using AdvocatApp.DAL.Repositories;
using AdvocatApp.BL.Interfaces;
using AdvocatApp.BL.Services;
namespace AdvocatApp.Util
{
    /// <summary>
    /// Зависимости Ninject
    /// </summary>
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

        /// <summary>
        /// Зависимости - здесь
        /// </summary>
        private void AddBindings()
        {
            kernel.Bind<IAdminManager>().To<AdminManager>();
            kernel.Bind<IUnitOfWork>().To<IdentityUnitOfWork>();
            kernel.Bind<IServiceCreator>().To<ServiceCreator>();
            kernel.Bind<ISiteService>().To<SiteService>();
        }
    }
}