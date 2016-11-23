using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.BL.DTO
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }  // заголовок меню
        public string Url { get; set; } // адрес ссылки
        public int? Order { get; set; }  // порядок следования пункта в подменю
        public int? ParentId { get; set; }  // ссылка на id родительского меню
        public MenuDTO Parent { get; set; }    // родительское меню
        public int? PageId { get; set; }
        public ICollection<MenuDTO> Children { get; set; }   // дочерние пункты меню
        public MenuDTO()
        {
            Children = new List<MenuDTO>();
        }
    }
}
