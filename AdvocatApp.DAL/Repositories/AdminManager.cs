using AdvocatApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvocatApp.DAL.Authorization.Entities;
using AdvocatApp.DAL.Authorization.EF;

namespace AdvocatApp.DAL.Repositories
{
    public class AdminManager : IAdminManager
    {
        public ApplicationContext Database { get; set; }

        public AdminManager(ApplicationContext db)
        {
            Database = db;
        }
        public void Create(AboutAdmin item)
        {
            Database.AboutAdmin.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Update(AboutAdmin item)
        {
            Database.Entry(item).State = System.Data.Entity.EntityState.Modified;
            Database.SaveChanges();
        }

        public AboutAdmin GetInfo()
        {
            return Database.AboutAdmin.FirstOrDefault();
        }

        public void Delete()
        {
            var v = Database.AboutAdmin.First();
            if(v!=null)
            {
                Database.AboutAdmin.Remove(v);
            }
            Database.SaveChanges();
        }
    }
}
