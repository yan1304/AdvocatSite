using AdvocatApp.DAL.EF;
using AdvocatApp.DAL.Entities;
using AdvocatApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Repositories
{
    public class MenuRepository : IRepository<Menu>
    {
        private SiteContext db;

        public MenuRepository(SiteContext context)
        {
            db = context;
        }

        public void Create(Menu item)
        {
            db.MenuItems.Add(item);
        }

        public void Delete(int id)
        {
            Menu menu = db.MenuItems.Find(id);
            if (menu != null)
                db.MenuItems.Remove(menu);
        }

        public async void DeleteAsync(int id)
        {
            Menu menu = await db.MenuItems.FindAsync(id);
            if (menu != null)
                db.MenuItems.Remove(menu);
        }

        public IEnumerable<Menu> Find(Func<Menu, bool> predicate)
        {
            return db.MenuItems.Where(predicate).ToList();
        }

        public Menu Get(int id)
        {
            return db.MenuItems.Find(id);
        }

        public async Task<Menu> GetAsync(int id)
        {
            return await db.MenuItems.FindAsync(id);
        }

        public IEnumerable<Menu> GetAll()
        {
            return db.MenuItems;
        }

        public void Update(Menu item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
