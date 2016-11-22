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
    class SiteService : ISiteService
    {
        IUnitOfWorkSite Database { get; set; }

        public SiteService(IUnitOfWorkSite uow)
        {
            Database = uow;
        }
        public void AddPage(PageDTO pageDTO)
        {
            var v = Database.Pages.Find(p => p.Header == pageDTO.Header).FirstOrDefault();
            if(v==null)
            {
                Database.Pages.Create(ServiceFunctions.FromPageDTO(pageDTO));
                var m1 = Database.MenuItems.Find(menu => menu.Id == pageDTO.Id).FirstOrDefault();
                if (m1 != null) throw new ValidationExeption("Ошибка создания нового пункта меню", "MenuItems");
                if (pageDTO.Name != "Index")
                {
                    AddMenuItem(ServiceFunctions.MenuDTOFromPageDTO(pageDTO));
                }
                Database.Save();
            }
            else
            {
                UpdatePage(pageDTO);
                if(pageDTO.Name != "Index")
                {
                    var m = Database.MenuItems.Find(menu => menu.Id == pageDTO.Id).FirstOrDefault();
                    if (m != null)
                    {
                        Database.MenuItems.Update(ServiceFunctions.MenuFromPageDTO(pageDTO));
                    }
                    else throw new ValidationExeption("Ошибка обновления меню", "MenuItems");
                }
                Database.Save();
            }
        }

        public void AddQuestion(QuestionDTO questionDTO)
        {
            var v = Database.Questions.Find(p => p.Ask == questionDTO.Ask).FirstOrDefault();
            if (v == null)
            {
                Database.Questions.Create(ServiceFunctions.FromQuestionDTO(questionDTO));
                Database.Save();
            }
            else
            {
                UpdateQuestion(questionDTO);
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

        public void DeleteQuestion(int? id)
        {
            if (id == null)
            {
                throw new ValidationExeption("Не установлено id вопроса", "");
            }
            Database.Questions.Delete(id.Value);
            Database.Save();
        }

        public async Task DeleteQuestionAsync(int? id)
        {
            if (id == null)
            {
                throw new ValidationExeption("Не установлено id вопроса", "");
            }
            await Database.Questions.DeleteAsync(id.Value);
            await Database.SaveAsync();
        }
        
        public MenuDTO GetMenuItem(int? id)
        {
            if (id == null)
                throw new ValidationExeption("Не установлено id ячейки меню", "");
            var menu = Database.MenuItems.Get(id.Value);
            if(menu == null)
                throw new ValidationExeption("Ячейка меню не найдена", "");
            return ServiceFunctions.FromMenu(menu);
        }

        public async Task<MenuDTO> GetMenuItemAsync(int? id)
        {
            if (id == null)
                throw new ValidationExeption("Не установлено id ячейки меню", "");
            var menu = await Database.MenuItems.GetAsync(id.Value);
            if (menu == null)
                throw new ValidationExeption("Ячейка меню не найдена", "");
            return ServiceFunctions.FromMenu(menu);
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

        public QuestionDTO GetQuestion(int? id)
        {
            if(id == null)
                throw new ValidationExeption("Не установлено id вопроса", "");
            var question = Database.Questions.Get(id.Value);
            if (question == null)
                throw new ValidationExeption("Вопрос не найден", "");
            return ServiceFunctions.FromQuestion(question);
        }

        public async Task<QuestionDTO> GetQuestionAsync(int? id)
        {
            if (id == null)
                throw new ValidationExeption("Не установлено id вопроса", "");
            var question = await Database.Questions.GetAsync(id.Value);
            if (question == null)
                throw new ValidationExeption("Вопрос не найден", "");
            return ServiceFunctions.FromQuestion(question);
        }

        public void UpdatePage(PageDTO pageDTO)
        {
            Database.Pages.Update(ServiceFunctions.FromPageDTO(pageDTO));
            Database.Save();
        }

        public void UpdateQuestion(QuestionDTO questionDTO)
        {
            Database.Questions.Update(ServiceFunctions.FromQuestionDTO(questionDTO));
            Database.Save();
        }

        public async Task AddPageAsync(PageDTO pageDTO)
        {
            var v = Database.Pages.Find(p => p.Header == pageDTO.Header).FirstOrDefault();
            if (v == null)
            {
                Page p = new Page
                {
                    Id = pageDTO.Id,
                    Name = pageDTO.Name,
                    Header = pageDTO.Header,
                    Text = pageDTO.Text,
                    Date = pageDTO.Date,
                    VideoURL = pageDTO.VideoURL
                };
                Database.Pages.Create(p);
                var m1 =Database.MenuItems.Find(menu => menu.Id == pageDTO.Id).FirstOrDefault();
                if (m1 != null) throw new ValidationExeption("Ошибка создания нового пункта меню", "MenuItems");
                if (pageDTO.Name != "Index")
                {
                    MenuDTO m = new MenuDTO();
                    m.Id = pageDTO.Id;
                    m.Header = pageDTO.Header;
                    m.Url = "/Pages/" + pageDTO.Name;
                    await AddMenuItemAsync(m);
                }
                await Database.SaveAsync();
            }
            else
            {
                UpdatePage(pageDTO);
                if (pageDTO.Name != "Index")
                {
                    var m = Database.MenuItems.Find(menu => menu.Id == pageDTO.Id).FirstOrDefault();
                    if (m != null)
                    {
                        m.Header = pageDTO.Header;
                        Database.MenuItems.Update(m);
                    }
                    else throw new ValidationExeption("Ошибка обновления меню", "MenuItems");
                }
                await Database.SaveAsync();
            }
        }

        public async Task AddQuestionAsync(QuestionDTO questionDTO)
        {
            var v = Database.Questions.Find(p => p.Ask == questionDTO.Ask).FirstOrDefault();
            if (v == null)
            {
                Database.Questions.Create(ServiceFunctions.FromQuestionDTO(questionDTO));
                await Database.SaveAsync();
            }
            else
            {
                UpdateQuestion(questionDTO);
                await Database.SaveAsync();
            }
        }

        public void AddMenuItem(MenuDTO menuDTO)
        {
            var v = Database.MenuItems.Find(p => p.Id == menuDTO.Id).FirstOrDefault();
            if (v == null)
            {
                Database.MenuItems.Create(ServiceFunctions.FromMenuDTO(menuDTO));
                Database.Save();
            }
            else
            {
                UpdateMenu(menuDTO);
                Database.Save();
            }
        }

        public void UpdateMenu(MenuDTO menuDTO)
        {
            Database.MenuItems.Update(ServiceFunctions.FromMenuDTO(menuDTO));
            Database.Save();
        }

        public async Task UpdateMenuAsync(MenuDTO menuDTO)
        {
            Database.MenuItems.Update(ServiceFunctions.FromMenuDTO(menuDTO));
            await Database.SaveAsync();
        }

        public async Task AddMenuItemAsync(MenuDTO menuDTO)
        {
            var v = Database.MenuItems.Find(p => p.Id == menuDTO.Id).FirstOrDefault();
            if (v == null)
            {
                Database.MenuItems.Create(ServiceFunctions.FromMenuDTO(menuDTO));
                await Database.SaveAsync();
            }
            else
            {
                UpdateMenu(menuDTO);
                await Database.SaveAsync();
            }
        }

        public void DeleteMenuItem(int? id)
        {
            if(id == null)
            {
                throw new ValidationExeption("Не указан Id ячейки меню", "");
            }
            Database.MenuItems.Delete(id.Value);
            Database.Save();
        }

        public async Task DeleteMenuItemAsync(int? id)
        {
            if (id == null)
            {
                throw new ValidationExeption("Не указан Id ячейки меню", "");
            }
            await Database.MenuItems.DeleteAsync(id.Value);
            await Database.SaveAsync();
        }

        public async Task UpdatePageAsync(PageDTO pageDTO)
        {
            Database.Pages.Update(ServiceFunctions.FromPageDTO(pageDTO));
            await Database.SaveAsync();
        }

        public async Task UpdateQuestionAsync(QuestionDTO questionDTO)
        {
            Database.Questions.Update(ServiceFunctions.FromQuestionDTO(questionDTO));
            await Database.SaveAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
