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

        private static LiteDatabase mDb;

        private const String PAGES_DATA = "pagesdata";
        private const String DB_NAME = "Prosto.db";

        private static LiteDatabase getDb(String _pathName)
        {
            if (mDb == null)
            {
                mDb = new LiteDatabase(_pathName);
            }
            return mDb;
        }

        public PageData GetPageDataById(int _id, String _DbPath)
        {
            PageData pageData = null;

            //using (var db = new LiteDatabase(_DbPath + DB_NAME))
            //{
            var db = LiteDBProjectRepository.getDb(_DbPath + DB_NAME);
            var pagesData =
                db.GetCollection<PageData>(PAGES_DATA);
            pageData = pagesData.FindById(_id);
            //}
            return pageData;
        }

        public PageData GetPageDataBySection(String _section, String _DbPath)
        {
            PageData pageData = null;
            var db = LiteDBProjectRepository.getDb(_DbPath + DB_NAME);
            //using (var db = new LiteDatabase(_DbPath + DB_NAME))
            //{
            var pagesData =
            db.GetCollection<PageData>(PAGES_DATA);
            pageData =
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
            //}
            return pageData;
        }

        public IEnumerable<PageData> GetPagesTitles(String _DbPath)
        {
            IEnumerable<PageData> pagesData = null;
            //using (var db = new LiteDatabase(_DbPath + DB_NAME))
            //{
            var db = LiteDBProjectRepository.getDb(_DbPath + DB_NAME);
            pagesData =
                db.GetCollection<PageData>(PAGES_DATA)
                .FindAll()
                .Select(
                    pd =>
                        new PageData {

                            id = pd.id
                            , title = pd.title
                        }
                );
            //}
            return pagesData;
        }

        public IEnumerable<PageData> GetPagesData(String _DbPath)
        {
            IEnumerable<PageData> pagesData = null;
            //using (var db = new LiteDatabase(_DbPath + DB_NAME))
            //{
            var db = LiteDBProjectRepository.getDb(_DbPath + DB_NAME);
            pagesData =
                db.GetCollection<PageData>(PAGES_DATA)
                .FindAll();
            //}
            return pagesData;
        }

        public PageData SavePageData(PageData _pageData, String _DbPath)
        {
            //using (var db = new LiteDatabase(_DbPath + DB_NAME))
            //{
            var db = LiteDBProjectRepository.getDb(_DbPath + DB_NAME);
            var pagesData =
                db.GetCollection<PageData>(PAGES_DATA);
            pagesData.Insert(_pageData);
            pagesData.EnsureIndex(pd => pd.id);
            //}
            return _pageData;
        }

        public PageData UpdatePageDataById(int _id, String _title, String _content, String _DbPath)
        {
            PageData pageData = null;
            //using (var db = new LiteDatabase(_DbPath + DB_NAME))
            //{
            var db = LiteDBProjectRepository.getDb(_DbPath + DB_NAME);
            var pagesData =
                db.GetCollection<PageData>(PAGES_DATA);
            pageData = pagesData.FindById(_id);
            if (pageData != null)
            {
                pageData.title = _title;
                pageData.content = _content;
                pagesData.Update(pageData);
                pagesData.EnsureIndex(pd => pd.id);
            }
            //}
            return pageData;
        }
    }
}
