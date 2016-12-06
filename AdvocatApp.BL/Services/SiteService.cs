using AdvocatApp.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvocatApp.BL.DTO;
using AdvocatApp.DAL.Interfaces;
using AdvocatApp.DAL.Entities;
using AdvocatApp.BL.Infrastructure;
using AdvocatApp.BL.BusinessModels;
using AutoMapper;

namespace AdvocatApp.BL.Services
{
    public class SiteService : ISiteService
    {
        IUnitOfWorkSite Database { get; set; }

        public SiteService(IUnitOfWorkSite uow)
        {
            Database = uow;
        }
        public void AddPage(PageDTO pageDTO)
        {
            var v = Database.Pages.Find(p => p.Name == pageDTO.Name).FirstOrDefault();
            if(v==null)
            {
                Database.Pages.Create(ServiceFunctions.FromPageDTO(pageDTO));
                Database.Save();
            }
            else
            {
                UpdatePage(pageDTO);
                Database.Save();
            }
        }

        public void DeletePage(int? id)
        {
            if(id == null)
            {
                throw new ValidationExeption("Не установлено id страницы", "");
            }
            Database.Pages.Delete(id.Value);
            Database.Save();
        }

        public async Task DeletePageAsync(int? id)
        {
            if (id == null)
            {
                throw new ValidationExeption("Не установлено id страницы", "");
            }
            await Database.Pages.DeleteAsync(id.Value);
            await Database.SaveAsync();
        }
      
        public PageDTO GetPage(int? id)
        {
            if (id == null)
                throw new ValidationExeption("Не установлено id статьи", "");
            var page = Database.Pages.Get(id.Value);
            if (page == null)
                throw new ValidationExeption("Статья не найдена", "");
            return ServiceFunctions.FromPage(page);
        }

        public async Task<PageDTO> GetPageAsync(int? id)
        {
            if(id == null)
                throw new ValidationExeption("Не установлено id статьи", "");
            var page =await  Database.Pages.GetAsync(id.Value);
            if (page == null)
                throw new ValidationExeption("Статья не найдена", "");
            return ServiceFunctions.FromPage(page);
        }

        public void UpdatePage(PageDTO pageDTO)
        {
            Database.Pages.Update(ServiceFunctions.FromPageDTO(pageDTO));
            Database.Save();
        }

        public async Task AddPageAsync(PageDTO pageDTO)
        {
            var v = Database.Pages.Find(p => p.Id == pageDTO.Id).FirstOrDefault();
            if (v == null)
            {
                Page p = ServiceFunctions.FromPageDTO(pageDTO);
                Database.Pages.Create(p);
                await Database.SaveAsync();
            }
            else
            {
                UpdatePage(pageDTO);
                await Database.SaveAsync();
            }
        }
        
        public async Task UpdatePageAsync(PageDTO pageDTO)
        {
            Database.Pages.Update(ServiceFunctions.FromPageDTO(pageDTO));
            await Database.SaveAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<PageDTO> GetPages()
        {
            IEnumerable<Page> page = Database.Pages.GetAll().ToList();
            List<PageDTO> p = new List<PageDTO>();
            foreach (Page item in page)
            {
                p.Add(ServiceFunctions.FromPage(item));
            }
            return p.ToList();
        }

        public IEnumerable<PageDTO> FindPage(Func<Page, bool> predicate)
        {
            List<Page> pages = Database.Pages.Find(predicate).ToList();
            List<PageDTO> page = new List<PageDTO>();
            foreach(Page p in pages)
            {
                page.Add(ServiceFunctions.FromPage(p));
            }
            return page;
        }
    }
}
