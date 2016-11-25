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
    }
}
