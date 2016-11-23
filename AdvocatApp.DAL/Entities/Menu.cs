using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Header { get; set; }  // заголовок меню
        public string Url { get; set; } // адрес ссылки
        public int? Order { get; set; }  // порядок следования пункта в подменю
        public int? ParentId { get; set; }  // ссылка на id родительского меню
        public Menu Parent { get; set; }    // родительское меню
        public int? PageId { get; set; }
        public ICollection<Menu> Children { get; set; }   // дочерние пункты меню
        public Menu()
        {
            Children = new List<Menu>();
        }
    }
}
