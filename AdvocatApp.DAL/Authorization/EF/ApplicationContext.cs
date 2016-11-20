using AdvocatApp.DAL.Authorization.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Authorization.EF
{
    public class ApplicationContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<AboutAdmin> AboutAdmin { get; set; }
    }
}
