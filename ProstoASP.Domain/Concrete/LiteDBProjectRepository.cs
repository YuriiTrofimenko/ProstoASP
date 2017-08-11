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
        //LiteCollection<PageData> IProjectRepository.PageData
        //{
        //    //get => db.GetCollection<PageData>("pagesData");
        //    get => null;
        //}
        private const String DB_NAME = @"Prosto.db";
        private const String PAGES_DATA = "pagesdata";

        public PageData GetPageDataById(int _id)
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var pagesData =
                    db.GetCollection<PageData>(PAGES_DATA);
                PageData pageData = pagesData.FindById(_id);

                return pageData;
            }
        }

        public PageData GetPageDataBySection(String _section)
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var pagesData =
                    db.GetCollection<PageData>(PAGES_DATA);
                PageData pageData =
                    pagesData.Find(pd => (pd.section.Equals(_section)))
                    .Select(
                        pd =>
                            new PageData
                            {

                                title = pd.title
                                , content = pd.content
                            }
                    )
                    .FirstOrDefault();

                return pageData;
            }
        }

        public IEnumerable<PageData> GetPagesTitles()
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var pagesData =
                    db.GetCollection<PageData>(PAGES_DATA)
                    .FindAll()
                    .Select(
                        pd =>
                            new PageData {

                                id = pd.id
                                , title = pd.title
                            }
                    );

                return pagesData;
            }
        }

        public IEnumerable<PageData> GetPagesData()
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var pagesData =
                    db.GetCollection<PageData>(PAGES_DATA)
                    .FindAll();

                return pagesData;
            }
        }

        public PageData SavePageData(PageData _pageData)
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var pagesData =
                    db.GetCollection<PageData>(PAGES_DATA);
                pagesData.Insert(_pageData);
                pagesData.EnsureIndex(pd => pd.id);
                return _pageData;
            }
        }

        public PageData UpdatePageDataById(int _id, String _title, String _content)
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var pagesData =
                    db.GetCollection<PageData>(PAGES_DATA);
                PageData pageData = pagesData.FindById(_id);
                if (pageData != null)
                {
                    pageData.title = _title;
                    pageData.content = _content;
                    pagesData.Update(pageData);
                    pagesData.EnsureIndex(pd => pd.id);
                }
                return pageData;
            }
        }
    }
}
