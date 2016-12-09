using AdvocatApp.BL.Authorization.DTO;
using AdvocatApp.BL.Authorization.Interfaces;
using AdvocatApp.Models;
using AutoMapper;
using BotDetect.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Controllers
{
    /// <summary>
    /// Контроллер для ASP Identity
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// Выделение текста статьи в теги <p/> для выделения параграфов
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string ReplaceStringTags(string str)
        {
            StringBuilder s = new StringBuilder("<p>");
            s = s.Append(str);
            s = s.Replace("<sc", "<sr");
            s = s.Replace("<Sc", "<sr");
            s = s.Replace("<SC", "<sr");
            s = s.Replace("<sC", "<sr");
            s = s.Replace("\r\n", "</p><p>");
            s = s.Append("</p>");
            s = s.Replace("<p><p>", "<p>");
            s = s.Replace("</p></p>", "</p>");
            return s.ToString();
        }

        private IUserService UserService //данные сайта (статьи, новости, уведомления)
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

        /// <summary>
        /// Страница авторизации администратора
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            if (UserService.GetInfo() != null)
            {
                ViewBag.Phone = UserService.GetInfo().Phone;
                ViewBag.Address = UserService.GetInfo().Address;
                ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                ViewBag.AnotherPhone = UserService.GetInfo().AnotherPhone;
            }
            return View();
        }

        /// <summary>
        /// Страница авторизации администратора (POST)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Введено неверное значение с картинки!")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                MvcCaptcha.ResetCaptcha("ExampleCaptcha");
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

        /// <summary>
        /// Редактирование информации о владельце (POST)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditAbout(ChangeAboutModel adm)
        {
            adm.AboutMe = ReplaceStringTags(adm.AboutMe);
            adm.TextForContacts = ReplaceStringTags(adm.TextForContacts);
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

        /// <summary>
        /// Редактирование данных авторизации
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult EditLogin()
        {
            if (UserService.GetInfo() != null)
            {
                ViewBag.Phone = UserService.GetInfo().Phone;
                ViewBag.Address = UserService.GetInfo().Address;
                ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                ViewBag.AnotherPhone = UserService.GetInfo().AnotherPhone;
            }
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

        /// <summary>
        /// Редактирование данных авторизации(POST)
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Выход из режима админа
        /// </summary>
        /// <returns></returns>
    public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Начальная инициализация
        /// </summary>
        /// <returns></returns>
        private async Task SetInitialDataAsync()
        {
            //Проверяем, что данных еще нет в БД
            if (UserService.GetInfo() == null)
            {
                await UserService.SetInitialData(new AdminDTO
                {
                    NameOfSite = "Корпоративный правовой центр",
                    Email = "admin",
                    Password = "12345",
                    Phone = "89160161601"
                });
            }
        }
    }
}