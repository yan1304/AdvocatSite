using AdvocatApp.BL.Authorization.DTO;
using AdvocatApp.BL.Authorization.Interfaces;
using AdvocatApp.BL.Authorization.Services;
using AdvocatApp.BL.DTO;
using AdvocatApp.BL.Interfaces;
using AdvocatApp.DAL.Entities;
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
    public class HomeController : Controller
    {
        ISiteService siteService;
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

        public HomeController(ISiteService serv)
        {
            siteService = serv;
        }
        
        public ActionResult Index()
        {
            if (UserService.GetInfo() != null)
            {
                ViewBag.Phone = UserService.GetInfo().Phone;
                ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
            }
            return View(siteService.GetPages().ToList());
        }
        
        [HttpPost]
        public ActionResult Page(PageDTO page)
        {
            if (page == null) page = new PageDTO();
            return PartialView(page);
        }
        
        public async Task<JsonResult> GetPage(int id)
        {
            var page = await siteService.GetPageAsync(id);
            return Json(
                new
                {
                    Id = page.Id,
                    VideoURL = page.VideoURL,
                    Header = page.Header,
                    Date = page.Date.Day + ":" + page.Date.Month + ":" + page.Date.Year,
                    Text = page.Text
                },
                JsonRequestBehavior.AllowGet
                );
        }

        public ActionResult About()
        {
            if (UserService.GetInfo() != null)
            {
                ViewBag.Phone = UserService.GetInfo().Phone;
                ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                return View(UserService.GetInfo());
            }
            else return HttpNotFound();
        }
        
        [HttpGet]
        public JsonResult GetWarringPageList(int pageNum)
        {
            int coll = 10;
            var pages = siteService.GetPages().Where(p => p.Type == TypePage.Warrings).OrderByDescending(p => p.Date).Skip(coll * (pageNum - 1)).Take(coll).ToList();
            List<object> newPages = new List<object>();
            foreach (var page in pages)
            {
                var p = new
                {
                    Id = page.Id,
                    VideoURL = page.VideoURL,
                    Header = page.Header,
                    Date = page.Date.Day + ":" + page.Date.Month + ":" + page.Date.Year,
                    Text = page.Text
                };
                newPages.Add(p);
            }
            return Json(
                newPages,
                JsonRequestBehavior.AllowGet
                );
        }
        
        [HttpGet]
        public JsonResult GetNewsPageList(int pageNum)
        {
            int coll = 10;
            var pages = siteService.GetPages().Where(p => p.Type == TypePage.News).OrderByDescending(p => p.Date).Skip(coll * (pageNum - 1)).Take(pageNum).ToList();
            List<object> newPages = new List<object>();
            foreach (var page in pages)
            {
                var p = new
                {
                    Id = page.Id,
                    VideoURL = page.VideoURL,
                    Header = page.Header,
                    Date = page.Date.Day + ":" + page.Date.Month + ":" + page.Date.Year,
                    Text = page.Text
                };
                newPages.Add(p);
            }
            return Json(
                newPages,
                JsonRequestBehavior.AllowGet
                );
        }
    }
}