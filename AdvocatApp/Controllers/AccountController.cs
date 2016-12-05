using AdvocatApp.BL.Authorization.DTO;
using AdvocatApp.BL.Authorization.Interfaces;
using AdvocatApp.Models;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Controllers
{
    public class AccountController : Controller
    {
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                AdminDTO userDto = new AdminDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditAbout(ChangeAboutModel adm)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<ChangeAboutModel, AdminDTO>());
                var q = Mapper.Map<ChangeAboutModel, AdminDTO>(adm);
                string s = User.Identity.Name;
                await UserService.Update(q, s);
                Thread.Sleep(200);
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("EditAbout", "Admin",adm);
        }
        
        [Authorize]
        public ActionResult EditLogin()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AdminDTO, ChangeAboutModel>());
            var q = Mapper.Map<AdminDTO, ChangeAboutModel>(UserService.GetInfo());
            if (q != null)
            {
                ViewBag.Phone = q.Phone;
                ViewBag.NameOfSite = q.NameOfSite;
            }
            LoginModel login = new LoginModel();
            login.Email = User.Identity.Name;
            login.Password = "";
            return View(login);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditLogin(LoginModel NewLogin)
        {
            if (ModelState.IsValid)
            {
                AdminDTO adm = UserService.GetInfo();
                adm.Password = NewLogin.Password;
                adm.Email = NewLogin.Email;
                string s = User.Identity.Name;
                await UserService.Update(adm, s);
                Thread.Sleep(200);
                return RedirectToAction("Index", "Admin");
            }
            return View(NewLogin);
        }

    public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        private async Task SetInitialDataAsync()
        {
            if (UserService.GetInfo() == null)
            {
                await UserService.SetInitialData(new AdminDTO
                {
                    NameOfSite = "Корпоративный правовой центр",
                    Email = "yan1304@mail.ru",
                    Password = "fil130494",
                    Name = "Ян",
                    Surname = "",
                    Fathername = "",
                    AboutMe = "",
                    Phone = "89160161601",
                    Vk = "",
                    Youtube = "",
                    Facebook = "",
                    Twitter = "",
                    HomePhone = "",
                    GooglePl = "",
                    Address = "ул. Спортивная, д.30, кв.75"
                });
            }
        }
    }
}