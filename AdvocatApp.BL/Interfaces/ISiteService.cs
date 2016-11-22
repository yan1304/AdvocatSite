using AdvocatApp.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.BL.Interfaces
{
    public interface ISiteService
    {
        void AddPage(PageDTO pageDTO);
        Task AddPageAsync(PageDTO pageDTO);
        PageDTO GetPage(int? id);
        Task<PageDTO> GetPageAsync(int? id);
        void UpdatePage(PageDTO pageDTO);
        Task UpdatePageAsync(PageDTO pageDTO);
        void DeletePage(int? id);
        Task DeletePageAsync(int? id);

        MenuDTO GetMenuItem(int? id);
        void AddMenuItem(MenuDTO menuDTO);
        Task AddMenuItemAsync(MenuDTO menuDTO);
        Task<MenuDTO> GetMenuItemAsync(int? id);
        void UpdateMenu(MenuDTO menuDTO);
        Task UpdateMenuAsync(MenuDTO menuDTO);
        void DeleteMenuItem(int? id);
        Task DeleteMenuItemAsync(int? id);

        void AddQuestion(QuestionDTO questionDTO);
        Task AddQuestionAsync(QuestionDTO pageDTO);
        QuestionDTO GetQuestion(int? id);
        Task<QuestionDTO> GetQuestionAsync(int? id);
        void UpdateQuestion(QuestionDTO questionDTO);
        Task UpdateQuestionAsync(QuestionDTO questionDTO);
        void DeleteQuestion(int? id);
        Task DeleteQuestionAsync(int? id);

        void Dispose();
    }
}
