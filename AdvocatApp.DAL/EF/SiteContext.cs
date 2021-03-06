﻿using AdvocatApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.EF
{
    public class SiteContext: DbContext
    {
        public DbSet<Page> Pages { get; set; }
        
        static SiteContext()
        {
            Database.SetInitializer<SiteContext>(new SiteDbInitializer());
        }

        public SiteContext(string connectionString):base(connectionString)
        {

        }
    }
}
