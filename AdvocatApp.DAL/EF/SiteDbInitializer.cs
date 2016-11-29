using AdvocatApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AdvocatApp.DAL.EF
{
    internal class SiteDbInitializer : DropCreateDatabaseAlways<SiteContext>, IDatabaseInitializer<SiteContext> 
    {
        protected override void Seed(SiteContext db)
        {

            List<Page> pages = new List<Page>
            {
                new Page {Id=1, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index", Date=DateTime.Now, Type=TypePage.Statie},
                new Page {Id=2, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Statie},
                new Page {Id=3, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Statie},
            };

            db.Pages.AddRange(pages);
            db.SaveChanges();
        }
    }
}