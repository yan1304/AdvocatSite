using AdvocatApp.BL.Authorization.Interfaces;
using AdvocatApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.BL.Authorization.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
