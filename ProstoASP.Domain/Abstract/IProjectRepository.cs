using LiteDB;
using ProstoASP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstoASP.Domain.Abstract
{
    public interface IProjectRepository
    {
        PageData SavePageData(PageData _pageData);
        PageData GetPageDataById(int _id);
        PageData GetPageDataBySection(String _section);
        PageData UpdatePageDataById(int _id, String _title, String _content);
        IEnumerable<PageData> GetPagesTitles();
        IEnumerable<PageData> GetPagesData();
        //LiteCollection<PageData> PageData { get; }
    }
}
