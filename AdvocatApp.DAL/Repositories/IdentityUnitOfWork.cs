using AdvocatApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvocatApp.DAL.Authorization.Identity;
using AdvocatApp.DAL.Authorization.EF;
using Microsoft.AspNet.Identity.EntityFramework;
using AdvocatApp.DAL.Authorization.Entities;

namespace AdvocatApp.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private ApplicationUserManager userManager;
        private IAdminManager adminManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            adminManager = new AdminManager(db);
        }

        public IAdminManager AdminManager
        {
            get { return adminManager; }
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    userManager.Dispose();
                    adminManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
