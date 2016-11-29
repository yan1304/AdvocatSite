using AdvocatApp.BL.DTO;
using AdvocatApp.DAL.Entities;
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
        IEnumerable<PageDTO> GetPages();
        Task<PageDTO> GetPageAsync(int? id);
        void UpdatePage(PageDTO pageDTO);
        Task UpdatePageAsync(PageDTO pageDTO);
        void DeletePage(int? id);
        Task DeletePageAsync(int? id);
        IEnumerable<PageDTO> FindPage(Func<Page, bool> predicate);
        

        void Dispose();
    }
}
