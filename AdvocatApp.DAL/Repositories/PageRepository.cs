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
    public class PageRepository : IRepository<Page>
    {
        private SiteContext db;

        public PageRepository(SiteContext context)
        {
            db = context;
        }
        public void Create(Page item)
        {
            db.Pages.Add(item);
        }

        public void Delete(int id)
        {
            Page page = db.Pages.Find(id);
            if (page != null)
                db.Pages.Remove(page);
        }
        public async Task DeleteAsync(int id)
        {
            Page page = await  db.Pages.FindAsync(id);
            if (page != null)
                db.Pages.Remove(page);
        }

        public IEnumerable<Page> Find(Func<Page, bool> predicate)
        {
            return db.Pages.Where(predicate).ToList();
        }

        public Page Get(int id)
        {
            return db.Pages.Find(id);
        }

        public IEnumerable<Page> GetAll()
        {
            return db.Pages;
        }

        public async Task<Page> GetAsync(int id)
        {
            return await db.Pages.FindAsync(id);
        }
        public void Update(Page item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
