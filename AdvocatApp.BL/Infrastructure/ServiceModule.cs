using AdvocatApp.DAL.Interfaces;
using AdvocatApp.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.BL.Infrastructure
{
    public class ServiceModule:NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWorkSite>().To<EFUnitOfWorkSite>().WithConstructorArgument(connectionString);
        }
    }
}
