using AdvocatApp.DAL.Authorization.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ApplicationUserManager UserManager { get;}
        IAdminManager AdminManager { get; }
        Task SaveAsync();
    }
}
