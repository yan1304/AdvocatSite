using AdvocatApp.BL.Authorization.DTO;
using AdvocatApp.BL.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.BL.Authorization.Interfaces
{
    public interface IUserService:IDisposable
    {
        Task<AdminDTO> GetUser(string email);
        Task<OperationDetails> Create(AdminDTO adminDto);
        Task<ClaimsIdentity> Authenticate(AdminDTO adminDto);
        Task SetInitialData(AdminDTO adminDto);//установка начальных данных в БД
    }
}
