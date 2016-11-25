﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Models
{
    public class ChangeAboutModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string Phone { get; set; }
        public string HomePhone { get; set; }
        public string Vk { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string GooglePl { get; set; }
        public string Youtube { get; set; }
        public string Address { get; set; }
        public string AboutMe { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}