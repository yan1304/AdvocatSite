using AdvocatApp.DAL.Authorization.Entities;
using Microsoft.AspNet.Identity;

namespace AdvocatApp.DAL.Authorization.Identity
{
    class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }
    }
}
