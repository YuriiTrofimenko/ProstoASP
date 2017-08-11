using ProstoASP.Domain.Abstract;
using ProstoASP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProstoASP.Web.Controllers
{
    public class AdminController : Controller
    {
        private IProjectRepository mRepository;
        private String DB_PATH;

        public AdminController(IProjectRepository _projectRepository)
        {

            mRepository = _projectRepository;
            
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DoAction()
        {
            dynamic result = new { };
            if (Request["action"] != null)
            {
                String actionString = Request["action"];
                DB_PATH = Server.MapPath("~/App_Data/");
                switch (actionString)
                {
                    case "create-page-data":
                        {
                            if (Request["section"] != null
                                && Request["title"] != null
                                && Request["content"] != null)
                            {
                                PageData pageData = new PageData();
                                pageData.section = Request["section"];
                                pageData.title = Request["title"];
                                pageData.content = Request["content"];
                                try
                                {
                                    mRepository.SavePageData(pageData, DB_PATH);
                                    result = new { ok = "ok" };
                                }
                                catch (Exception ex)
                                {

                                    result = new { error = "error", message = ex.Message };
                                }
                            }
                            break;
                        }
                    case "edit-page-data":
                        {
                            if (Request["id"] != null
                                && Request["title"] != null
                                && Request["content"] != null)
                            {
                                try
                                {
                                    mRepository.UpdatePageDataById(
                                            Int32.Parse(Request["id"])
                                            , Request["title"]
                                            , Request["content"]
                                            , DB_PATH);
                                    result = new { ok = "ok" };
                                }
                                catch (Exception)
                                {

                                    result = new { error = "error" };
                                }
                            }
                            break;
                        }
                    case "get-page-data":
                        {
                            if (Request["id"] != null)
                            {
                                try
                                {
                                    PageData pd = 
                                        mRepository.GetPageDataById(
                                                Int32.Parse(Request["id"])
                                                , DB_PATH);
                                    if (pd != null)
                                    {
                                        result =
                                            new {
                                                id = pd.id
                                                , title = pd.title
                                                , content = pd.content
                                            };
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception ex)
                                {

                                    result = new { error = "error", message = ex.Message };
                                }
                            }
                            break;
                        }
                    case "get-pages-data-lazy":
                        {
                            try
                            {
                                IEnumerable<PageData> pd =
                                    mRepository.GetPagesTitles(DB_PATH);
                                if (pd != null)
                                {
                                    result =
                                        new
                                        {
                                            pagesData = pd.ToArray()
                                        };
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                result = new { error = "error" };
                            }
                            break;
                        }
                    case "get-pages-data":
                        {
                            try
                            {
                                IEnumerable<PageData> pd =
                                    mRepository.GetPagesData(DB_PATH);
                                if (pd != null)
                                {
                                    result =
                                        new
                                        {
                                            pagesData = pd.ToArray()
                                        };
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                result = new { error = "error" };
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            //
            /*var result =
                from item in mRepository.Project
                where (item.Id == _projectId)
                select new { item.Id, item.User, item.Width, item.Height };
            return Json(result, JsonRequestBehavior.AllowGet);*/
            return Json(result);
        }
    }
}