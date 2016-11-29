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

        public static PageDTO FromPage(Page page)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Page, PageDTO>());
            return Mapper.Map<Page, PageDTO>(page);
        }
        

        public static Page FromPageDTO(PageDTO pageDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PageDTO, Page>());
            return Mapper.Map<PageDTO, Page>(pageDTO);
        }
    }
}
