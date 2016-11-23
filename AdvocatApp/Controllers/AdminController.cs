using AdvocatApp.BL.Authorization.Interfaces;
using AdvocatApp.BL.Authorization.Services;
using AdvocatApp.BL.DTO;
using AdvocatApp.BL.Interfaces;
using AdvocatApp.Models;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Controllers
{
    public class AdminController : Controller
    {
        ISiteService siteService;
        public AdminController(ISiteService serv)
        {
            siteService = serv;
        }
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Admin
        [Authorize]
        public async Task<ActionResult> Index()
        {
            return View(await UserService.GetUser(HttpContext.User.Identity.Name));
        }
        [Authorize]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public ActionResult Pages()
        {
            return PartialView(siteService.GetPages());
        }
        [Authorize]
        public ActionResult Menus()
        {
            return PartialView(siteService.GetMenuItems());
        }
        [Authorize]
        public ActionResult Questions()
        {
            return PartialView(siteService.GetQuestions());
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Page(int? id)
        {
            if (id == null) RedirectToAction("Index");
            PageDTO page = await siteService.GetPageAsync(id);
            if (page == null)
                HttpNotFound();
            return View(page);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddPage()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddPage(PageModel p)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PageModel, PageDTO>());
            var page = Mapper.Map<PageModel, PageDTO>(p);
            page.Date = DateTime.Now;
            StringBuilder s = new StringBuilder("<p>");
            s = s.Append(page.Text);
            s = s.Replace("<sc", "<sr");
            s = s.Replace("<Sc", "<sr");
            s = s.Replace("<SC", "<sr");
            s = s.Replace("<sC", "<sr");
            s = s.Replace("\r\n","</p><p>");
            s = s.Append("</p>");
            page.Text = s.ToString();
            await siteService.AddPageAsync(page);
            return RedirectToAction("Index");
        }
    }
}