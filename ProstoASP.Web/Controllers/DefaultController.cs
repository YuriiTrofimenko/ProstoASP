using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProstoASP.Domain.Entity;

namespace ProstoASP.Web.Controllers
{
    public class DefaultController : Controller
    {
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
                                PageData pageData =
                                    new PageData(
                                        "home"
                                        , "Главная"
                                        , "Зачем усложнять себе жизнь, если все можно просто поручить профи?.."
                                    );
                                result =
                                    new {
                                        id = pageData.getId()
                                        , title = pageData.getTitle()
                                        , content = pageData.getContent()
                                    };
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