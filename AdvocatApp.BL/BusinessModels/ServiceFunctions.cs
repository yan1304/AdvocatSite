using AdvocatApp.BL.DTO;
using AdvocatApp.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.BL.BusinessModels
{
    public static class ServiceFunctions
    {
        public static QuestionDTO FromQuestion(Question question)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Question, QuestionDTO>());
            return Mapper.Map<Question, QuestionDTO>(question);
        }

        public static MenuDTO FromMenu(Menu menu)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Menu, MenuDTO>());
            return Mapper.Map<Menu, MenuDTO>(menu);
        }
        public static PageDTO FromPage(Page page)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Page, PageDTO>());
            return Mapper.Map<Page, PageDTO>(page);
        }

        public static Question FromQuestionDTO(QuestionDTO questionDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<QuestionDTO, Question>());
            return Mapper.Map<QuestionDTO, Question>(questionDTO);
        }

        public static Page FromPageDTO(PageDTO pageDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PageDTO, Page>());
            return Mapper.Map<PageDTO, Page>(pageDTO);
        }

        public static Menu FromMenuDTO(MenuDTO menuDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<MenuDTO, Menu>());
            return Mapper.Map<MenuDTO, Menu>(menuDTO);
        }

        public static MenuDTO MenuDTOFromPageDTO(PageDTO pageDTO)
        {
            MenuDTO m = new MenuDTO
            {
                Header = pageDTO.Header,
                Id = pageDTO.Id,
                Url = "/Pages/" + pageDTO.Name
            };
            return m;
        }

        public static Menu MenuFromPageDTO(PageDTO pageDTO)
        {
            Menu m = new Menu
            {
                Header = pageDTO.Header,
                Id = pageDTO.Id,
                Url = "/Pages/" + pageDTO.Name
            };
            return m;
        }
    }
}
