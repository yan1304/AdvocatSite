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
                new Page {Id=4, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Statie},
                new Page {Id=5, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Statie},
                new Page {Id=6, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Statie},
                new Page {Id=7, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index2", Date=DateTime.Now, Type=TypePage.Statie},
                new Page {Id=8, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Statie},
                new Page {Id=9, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Statie},
                new Page {Id=10, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index3", Date=DateTime.Now, Type=TypePage.Statie},
                new Page {Id=12, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Statie},
                new Page {Id=13, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Statie},
                new Page {Id=11, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Statie},
                new Page {Id=14, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Statie},
                new Page {Id=15, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Statie},
                new Page {Id=16, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Statie},
                new Page {Id=17, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=18, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=19, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Warrings},
                new Page {Id=20, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=23, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=21, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Warrings},
                new Page {Id=22, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=24, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=25, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Warrings},
                new Page {Id=26, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=27, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=28, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Warrings},
                new Page {Id=29, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=30, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=31, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Inde2x", Date=DateTime.Now, Type=TypePage.News},
                new Page {Id=32, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=33, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=41, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Inde2x", Date=DateTime.Now, Type=TypePage.News},
                new Page {Id=42, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=43, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=51, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.News},
                new Page {Id=52, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=53, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.News},
                 new Page {Id=129, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=130, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=131, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Inde2x", Date=DateTime.Now, Type=TypePage.News},
                new Page {Id=132, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=133, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=141, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Inde2x", Date=DateTime.Now, Type=TypePage.News},
                new Page {Id=142, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=143, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=151, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.News},
                new Page {Id=152, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.News},
                new Page {Id=153, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.News },
                new Page {Id=218, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=219, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Warrings},
                new Page {Id=220, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=223, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=221, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Warrings},
                new Page {Id=222, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=224, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=225, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Warrings},
                new Page {Id=226, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="Текст", Name="About", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=227, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Warrings},
                new Page {Id=228, Header="Главная", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="текст главной страницы", Name="Index1", Date=DateTime.Now, Type=TypePage.Warrings}
            };

            db.Pages.AddRange(pages);
            db.SaveChanges();
        }
    }
}