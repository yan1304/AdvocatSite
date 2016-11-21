using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Entities
{
    /// <summary>
    /// Модель статьи
    /// </summary>
    class Page
    {
        int Id { get; set; }
        string Name { get; set; }
        string VideoURL { get; set; }
        string Text { get; set; }
    }
}
