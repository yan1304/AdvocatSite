using AdvocatApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Interfaces
{
    public interface IUnitOfWorkSite:IDisposable
    {
        IRepository<Question> Questions { get;}
        IRepository<Page> Pages { get;}
        IRepository<Menu> MenuItems { get; }
        void Save();
        Task SaveAsync();
    }
}
