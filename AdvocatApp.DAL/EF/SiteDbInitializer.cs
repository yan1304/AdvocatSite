using AdvocatApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AdvocatApp.DAL.EF
{
    internal class SiteDbInitializer : DropCreateDatabaseIfModelChanges<SiteContext>, IDatabaseInitializer<SiteContext> 
    {
        protected override void Seed(SiteContext db)
        {

            List<Page> pages = new List<Page>
            {
                new Page {Id=1, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index", Date=DateTime.Now, Type=TypePage.Statie},
                new Page {Id=2, Header="Цены на услуги", VideoURL="", Text="<p><b>услуга 1</b> 1000р</p><p><b>услуга 2</b> 3020р</p>", Name="Price", Date=DateTime.Now,Type=TypePage.Statie}           
            };

            db.Pages.AddRange(pages);
            db.SaveChanges();
        }
    }
}