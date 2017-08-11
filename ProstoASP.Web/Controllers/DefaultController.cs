using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProstoASP.Domain.Entity;
using ProstoASP.Domain.Abstract;

namespace ProstoASP.Web.Controllers
{
    public class DefaultController : Controller
    {
        private IProjectRepository mRepository;

        public DefaultController(IProjectRepository _projectRepository)
        {

            mRepository = _projectRepository;
        }

        // GET: Default
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
                switch (actionString)
                {
                    case "get-data-by-section":
                        {
                            if (Request["section"] != null)
                            {
                                try
                                {
                                    result =
                                        mRepository.GetPageDataBySection(Request["section"]);
                                }
                                catch (Exception)
                                {

                                    result = new { error = "error" };
                                }
                            }
                            break;
                        }
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
                                    mRepository.SavePageData(pageData);
                                    result = new { ok = "ok" };
                                }
                                catch (Exception)
                                {

                                    result = new { error = "error" };
                                }
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