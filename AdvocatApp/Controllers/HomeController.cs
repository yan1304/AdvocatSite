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
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Controllers
{
    /// <summary>
    /// Контроллер пользовательской части сайта
    /// </summary>
    public class HomeController : Controller
    {
        ISiteService siteService; //данные сайта (статьи, новости, уведомления)
        private IUserService UserService //Данные авторизации и информация о владельце
        {
            get
            {
                if (HttpContext != null)
                {
                    if (HttpContext.GetOwinContext() != null)
                    {
                        return HttpContext.GetOwinContext().GetUserManager<IUserService>();
                    }
                    else return null;
                }
                else return null;
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
            if (UserService != null)
            {
                if (UserService.GetInfo() != null)
                {
                    ViewBag.Phone = UserService.GetInfo().Phone;
                    ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                }
            }
            return View(siteService.GetPages().ToList());
        }
        
        [HttpPost]
        public ActionResult Page(PageDTO page)
        {
            if (page == null) page = new PageDTO();
            return PartialView(page);
        }

        /// <summary>
        /// Информация о владельце
        /// </summary>
        public ActionResult About()
        {
            if (UserService != null)
            {
                if (UserService.GetInfo() != null)
                {
                    ViewBag.Phone = UserService.GetInfo().Phone;
                    ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                    return View(UserService.GetInfo());
                }
                else return HttpNotFound();
            }
            else return HttpNotFound();
        }
    }
}