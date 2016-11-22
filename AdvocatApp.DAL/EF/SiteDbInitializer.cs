using System;
using System.Data.Entity;

namespace AdvocatApp.DAL.EF
{
    internal class SiteDbInitializer : CreateDatabaseIfNotExists<SiteContext>, IDatabaseInitializer<SiteContext> 
    {
        protected override void Seed(SiteContext db)
        {

        }
    }
}