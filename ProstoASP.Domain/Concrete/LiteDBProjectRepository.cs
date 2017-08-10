using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProstoASP.Domain.Abstract;
using ProstoASP.Domain.Entity;
using LiteDB;

namespace ProstoASP.Domain.Concrete
{
    public class LiteDBProjectRepository : IProjectRepository
    {
        public LiteDatabase db;

        public LiteDBProjectRepository()
        {
            db = new LiteDatabase(@"Prosto.db");
        }

        LiteCollection<PageData> IProjectRepository.PageData
        {
            get => db.GetCollection<PageData>("PageDatas");
        }

        PageData IProjectRepository.SavePageData(PageData _pageData)
        {
            throw new NotImplementedException();
        }
    }
}
