using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdvocatApp.DAL.Authorization.Entities
{
    /// <summary>
    /// Информация об администраторе сайта
    /// </summary>
    public class AboutAdmin
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string NameOfSite { get; set; }
        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
        public string Vk { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string GooglePl { get; set; }
        public string Youtube { get; set; }
        public string Address { get; set; }
        public string AboutMe { get; set; }
        public string TextForContacts { get; set; }
        public string Email { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
