using AdvocatApp.BL.Authorization.DTO;
using AdvocatApp.BL.Authorization.Interfaces;
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
    /// <summary>
    /// Контроллер администраторской части сайта
    /// </summary>
    public class AdminController : Controller
    {
        ISiteService siteService; //данные сайта (статьи, новости, уведомления)
        public AdminController(ISiteService serv)
        {
            siteService = serv;
        }
        private IUserService UserService //Данные авторизации и информация о владельце
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
        public ActionResult Gide ()
        {
            return View();
        }
        // GET: Admin
        [Authorize]
        public ActionResult Index(int id=1)
        {
            ViewBag.Id = id;
            if (UserService.GetInfo() != null)
            {
                ViewBag.Phone = UserService.GetInfo().Phone;
                ViewBag.Address = UserService.GetInfo().Address;
                ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                ViewBag.AnotherPhone = UserService.GetInfo().AnotherPhone;
            }
            return View( siteService.GetPages().ToList());
        }
        [Authorize]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Добавление статьи
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult AddPage()
        {
            if (UserService != null)
            {
                ViewBag.Phone = UserService.GetInfo().Phone;
                ViewBag.Address = UserService.GetInfo().Address;
                ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                ViewBag.AnotherPhone = UserService.GetInfo().AnotherPhone;
            }
            return View();
        }
        /// <summary>
        /// Добавление статьи (POST)
        /// </summary>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddPage(PageModel p)
        {
            if (ModelState.IsValid)
            {
                if (p.Name == "Index" || p.Name == "Price") p.Name = "";
                p.Type = TypePage.Statie;
                return await AddPageFunc(p);
            }
            return View(p);
        }

        /// <summary>
        /// Добавление уведомления
        /// </summary>
        [Authorize]
        [HttpGet]
        public ActionResult AddWarringPage()
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
        /// Добавление уведомления(POST)
        /// </summary>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddWarringPage(PageModelWithoutVideo p)
        {
            if (ModelState.IsValid)
            {
                p.Type = TypePage.Warrings;
                return await AddPageFunc(p);
            }
            return View(p);
        }

        /// <summary>
        /// Добавление новости
        /// </summary>
        [Authorize]
        [HttpGet]
        public ActionResult AddNews()
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
        /// Добавление новости (POST)
        /// </summary>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddNews(PageModelWithoutVideo p)
        {
            if (ModelState.IsValid)
            {
                p.Type = TypePage.News;
                return await AddPageFunc(p);
            }
            else return View();
        }
        
        
        [Authorize]
        [HttpPost]
        public ActionResult Page(PageDTO page)
        {
            if (page == null) page = new PageDTO();
            return PartialView(page);
        }

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

        /// <summary>
        /// Обобщенная функция добавления статей
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <returns></returns>
        private async Task<ActionResult> AddPageFunc<T>(T p)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T, PageDTO>());
            var page = Mapper.Map<T, PageDTO>(p);
            page.Date = DateTime.Now;

            page.Text = ReplaceStringTags(page.Text);
            await siteService.AddPageAsync(page);
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Удаление статьи (открывает страницу с подтверждением действия)
        /// </summary>
        /// <param name="id">ид статьи</param>
        /// <returns></returns>
        [Authorize]
        public async Task<ActionResult> DeleteP(int id)
        {
            if (UserService.GetInfo() != null)
            {
                ViewBag.Phone = UserService.GetInfo().Phone;
                ViewBag.Address = UserService.GetInfo().Address;
                ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                ViewBag.AnotherPhone = UserService.GetInfo().AnotherPhone;
            }
            PageDTO page = await siteService.GetPageAsync(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        /// <summary>
        /// Удаление статьи 
        /// </summary>
        /// <param name="id">ид статьи</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, ActionName("DeleteP")]
        public async Task<ActionResult> DeletePage(int id)
        {
            if (id == 1 || id==2)
            {
                PageDTO page = await siteService.GetPageAsync(id);
                page.Header = "";
                page.Text = "";
                page.Date = DateTime.Now;
                page.VideoURL = null;
                await siteService.UpdatePageAsync(page);
            }
            else
            {
                await siteService.DeletePageAsync(id);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Редактирование статьи
        /// </summary>
        /// <param name="id">ид статьи</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> EditPage(int? id)
        {
            if (UserService.GetInfo() != null)
            {
                ViewBag.Phone = UserService.GetInfo().Phone;
                ViewBag.Address = UserService.GetInfo().Address;
                ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                ViewBag.AnotherPhone = UserService.GetInfo().AnotherPhone;
            }
            if (id == null) return HttpNotFound();
            var page = await siteService.GetPageAsync(id.Value);
            if (page == null) return HttpNotFound();
            Mapper.Initialize(cfg => cfg.CreateMap<PageDTO, PageModel>());
            var p = Mapper.Map<PageDTO, PageModel>(page);
            return View(p);
        }

        /// <summary>
        /// Редактирование статьи (POST)
        /// </summary>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditPage(PageModel p)
        {
            if (ModelState.IsValid)
            {
                //Проверка, что названия Главной страницы и страницы цен не были изменены
                if (p.Name == "Price" && p.Id != 2) p.Name = "";
                if (p.Id == 2) p.Name = "Price";
                if (p.Name == "Index" && p.Id != 1) p.Name = "";
                if (p.Id == 1) p.Name = "Index";
                Mapper.Initialize(cfg => cfg.CreateMap<PageModel, PageDTO>());
                var page = Mapper.Map<PageModel, PageDTO>(p);
                page.Text = ReplaceStringTags(page.Text);
                await siteService.UpdatePageAsync(page);

                return RedirectToAction("Index");
            }
            else return View(p.Id);
        }

        /// <summary>
        /// Редактирование информации о владельце
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult EditAbout()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AdminDTO, ChangeAboutModel>());
            var q = Mapper.Map<AdminDTO, ChangeAboutModel>(UserService.GetInfo());
            if (q != null)
            {
                ViewBag.Phone = q.Phone;
                ViewBag.NameOfSite = q.NameOfSite;
                ViewBag.AnotherPhone = q.AnotherPhone;
                ViewBag.Address = UserService.GetInfo().Address;
            }
            return View(q);
        }

        /// <summary>
        /// Информация о владельце
        /// </summary>
        [Authorize]
        public ActionResult About()
        {
            if (UserService.GetInfo() != null)
            {
                ViewBag.Phone = UserService.GetInfo().Phone;
                ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                ViewBag.AnotherPhone = UserService.GetInfo().AnotherPhone;
                ViewBag.Address = UserService.GetInfo().Address;
                return View(UserService.GetInfo());
            }
            else return HttpNotFound();
        }

        /// <summary>
        /// Контакты для связи с владельцем
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Contacts()
        {
            if(UserService.GetInfo()!=null)
            {
                ViewBag.Phone = UserService.GetInfo().Phone;
                ViewBag.NameOfSite = UserService.GetInfo().NameOfSite;
                ViewBag.AnotherPhone = UserService.GetInfo().AnotherPhone;
                ViewBag.Address = UserService.GetInfo().Address;
                return View(UserService.GetInfo());
            }
            return HttpNotFound();
        }
        /// <summary>
        /// Получение уведомления в JSON формате (для AJAX запросов)
        /// </summary>
        /// <param name="id">id статьи</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetWarringPageList(int pageNum)
        {
            int coll = 10;
            var pages = siteService.GetPages().Where(p=>p.Type==TypePage.Warrings).OrderByDescending(p=>p.Date).Skip(coll * (pageNum - 1)).Take(coll).ToList();
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

        /// <summary>
        /// Получение новости в JSON формате (для AJAX запросов)
        /// </summary>
        /// <param name="id">id статьи</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetNewsPageList(int pageNum)
        {
            int coll = 10;
            var pages = siteService.GetPages().Where(p => p.Type == TypePage.News).OrderByDescending(p => p.Date).Skip(coll * (pageNum - 1)).Take(coll).ToList();
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

        /// <summary>
        /// Получение статьи в JSON формате (для AJAX запросов)
        /// </summary>
        /// <param name="id">id статьи</param>
        /// <returns></returns>
        [HttpGet]
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
    }
}