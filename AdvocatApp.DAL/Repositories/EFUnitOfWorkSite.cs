using AdvocatApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvocatApp.DAL.Entities;
using AdvocatApp.DAL.EF;

namespace AdvocatApp.DAL.Repositories
{
    public class EFUnitOfWorkSite : IUnitOfWorkSite
    {
        private SiteContext db;
        private PageRepository pageRepository;
        private MenuRepository menuRepository;
        private QuestionRepository questionRepository;

        public EFUnitOfWorkSite(string connectionString)
        {
            db = new SiteContext(connectionString);
        }

        public IRepository<Menu> MenuItems
        {
            get
            {
                if (menuRepository == null)
                    menuRepository = new MenuRepository(db);
                return menuRepository;
            }
        }

        public IRepository<Page> Pages
        {
            get
            {
                if (pageRepository == null)
                    pageRepository = new PageRepository(db);
                return pageRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(db);
                return questionRepository;
            }
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
