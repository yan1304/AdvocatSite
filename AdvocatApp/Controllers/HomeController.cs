using AdvocatApp.BL.Authorization.Interfaces;
using AdvocatApp.BL.Authorization.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Controllers
{
    public class HomeController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}