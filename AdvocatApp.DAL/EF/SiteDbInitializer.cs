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
                new Page {Id=1, Header="Id1:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg", Name="Test", Date=DateTime.Now, Type=TypePage.Statie},
                new Page {Id=2, Header="Id2:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg2", Name="Test2", Date=DateTime.Now,Type=TypePage.Statie},
                new Page {Id=3, Header="Id3:", VideoURL="https://www.youtube.com/embed/FdBqOCS8LmM", Text="dfgfdg3", Name="Test3", Date=DateTime.Now,Type=TypePage.Statie}
            };

            db.Pages.AddRange(pages);

            List<Question> questions = new List<Question>
            {
                new Question { Id=1, Ask="Abc?", Resp="121"},
                new Question { Id=2, Ask="Abce?", Resp="22121"},
                new Question { Id=3, Ask="Abcgfg?", Resp="33333121"}
            };
            db.Questions.AddRange(questions);
            db.SaveChanges();
        }
    }
}