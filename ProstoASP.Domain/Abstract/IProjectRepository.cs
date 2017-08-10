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
        LiteCollection<PageData> PageData { get; }
    }
}
