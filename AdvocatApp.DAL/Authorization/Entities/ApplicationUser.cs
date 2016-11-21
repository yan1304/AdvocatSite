using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Authorization.Entities
{
    /// <summary>
    /// Модель для авторизации администратора
    /// </summary>
    public class ApplicationUser:IdentityUser
    { 
        public virtual AboutAdmin AboutAdmin { get; set; }
    }
}
