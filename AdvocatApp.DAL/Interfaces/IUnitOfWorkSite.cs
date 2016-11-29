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
        IRepository<Page> Pages { get;}
        void Save();
        Task SaveAsync();
    }
}
