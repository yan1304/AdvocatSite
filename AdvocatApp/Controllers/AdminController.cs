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
            p.Type = TypePage.Statie;
            return await AddPageFunc(p);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddPageWithVideo()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddPageWithVideo(PageModel p)
        {
            p.Type = TypePage.Warrings;
            return await AddPageFunc(p);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddWarringPage()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddWarringPage(PageModel p)
        {
            p.Type = TypePage.Warrings;
            return await AddPageFunc(p);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddPartners()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddPartners(PageModelWithoutVideo p)
        {
            p.Type = TypePage.Partners;
            return await AddPageFunc(p);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddNews()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddNews(PageModelWithoutVideo p)
        {
            p.Type = TypePage.News;
            return await AddPageFunc(p);
        }

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
            return s.ToString();
        }

        private async Task<ActionResult> AddPageFunc<T>(T p)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T, PageDTO>());
            var page = Mapper.Map<T, PageDTO>(p);
            page.Date = DateTime.Now;

            page.Text = ReplaceStringTags(page.Text);
            await siteService.AddPageAsync(page);
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<ActionResult> DeleteP(int id)
        {
            PageDTO page = await siteService.GetPageAsync(id);
            if(page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }


        [Authorize]
        [HttpPost, ActionName("DeleteP")]
        public async Task<ActionResult> DeletePage(int id)
        {
            await siteService.DeletePageAsync(id);
            return RedirectToAction("Index");
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult> EditPage(int? id)
        {
            if (id == null) return HttpNotFound();
            var page = await siteService.GetPageAsync(id.Value);
            if (page == null) return HttpNotFound();
            Mapper.Initialize(cfg => cfg.CreateMap<PageDTO, PageModel>());
            var p = Mapper.Map<PageDTO, PageModel>(page);
            return View(p);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditPage(PageModel p)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PageModel, PageDTO>());
            var page = Mapper.Map<PageModel, PageDTO>(p);
            page.Date = DateTime.Now;

            await siteService.UpdatePageAsync(page);

            return RedirectToAction("Index");
        }
        
        [Authorize]
        public ActionResult AddQuestion()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddQuestion(QuestionModel question)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<QuestionModel, QuestionDTO>());
            var quest = Mapper.Map<QuestionModel, QuestionDTO>(question);
            await siteService.AddQuestionAsync(quest);
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<ActionResult> EditQuestion(int? id)
        {
            if (id == null) return HttpNotFound();
            var quest = await siteService.GetQuestionAsync(id.Value);
            if (quest == null) return HttpNotFound();
            Mapper.Initialize(cfg => cfg.CreateMap<QuestionDTO, QuestionModel>());
            var q = Mapper.Map<QuestionDTO, QuestionModel>(quest);
            return View(q);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditQuestion(QuestionModel q)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<QuestionModel, QuestionDTO>());
            var question = Mapper.Map<QuestionModel, QuestionDTO>(q);

            await siteService.UpdateQuestionAsync(question);

            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<ActionResult> DeleteQ(int id)
        {
            QuestionDTO question = await siteService.GetQuestionAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }


        [Authorize]
        [HttpPost, ActionName("DeleteQ")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {
            await siteService.DeleteQuestionAsync(id);
            return RedirectToAction("Index");
        }

    }
}