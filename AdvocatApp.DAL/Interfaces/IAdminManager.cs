using AdvocatApp.DAL.Authorization.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Interfaces
{
    public interface IAdminManager:IDisposable
    {
        void Create(AboutAdmin item);
        void Update(AboutAdmin item);
        AboutAdmin GetInfo();
    }
}
