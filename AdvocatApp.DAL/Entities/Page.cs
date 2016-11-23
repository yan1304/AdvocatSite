using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Entities
{
    public enum TypePage
    {
        Statie,
        News,
        Warrings,
        Partners,
        VideoStatie
    }
    /// <summary>
    /// Модель статьи
    /// </summary>
    public class Page
    {
        public int Id { get; set; }
        public TypePage Type { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string VideoURL { get; set; }
        public string Text { get; set; }

       public  DateTime Date { get; set; }
    }
}
