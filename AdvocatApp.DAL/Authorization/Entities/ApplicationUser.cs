using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdvocatApp.DAL.Authorization.Entities
{
    /// <summary>
    /// Модель для авторизации администратора
    /// </summary>
    class ApplicationUser:IdentityUser
    {
        public virtual AboutAdmin AboutAdmin { get; set; }
    }
}
