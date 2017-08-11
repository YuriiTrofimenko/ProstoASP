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
        PageData SavePageData(PageData _pageData, String _DbPath);
        PageData GetPageDataById(int _id, String _DbPath);
        PageData GetPageDataBySection(String _section, String _DbPath);
        PageData UpdatePageDataById(int _id, String _title, String _content, String _DbPath);
        IEnumerable<PageData> GetPagesTitles(String _DbPath);
        IEnumerable<PageData> GetPagesData(String _DbPath);
        //LiteCollection<PageData> PageData { get; }
    }
}
