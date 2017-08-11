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
        private String DB_PATH;

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
            DB_PATH = Server.MapPath("~/App_Data/");
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
                                        mRepository.GetPageDataBySection(
                                            Request["section"]
                                            , DB_PATH
                                        );
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