using AdvocatApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.BL.DTO
{
    public class PageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string VideoURL { get; set; }
        public TypePage Type { get; set; }
        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}
