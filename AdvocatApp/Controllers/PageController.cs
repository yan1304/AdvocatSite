using AdvocatApp.BL.DTO;
using AdvocatApp.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Controllers
{
    public class PageController : Controller
    {
        ISiteService siteService;
        public PageController(ISiteService serv)
        {
            siteService = serv;
        }
        // GET: Page
        public ActionResult Pages()
        {
            return PartialView(siteService.GetPages());
        }

        [HttpGet]
        public async Task<ActionResult> Page(int id)
        {
            PageDTO page = await siteService.GetPageAsync(id);
            if (page == null)
                HttpNotFound();
            return View(page);
        }
    }
}