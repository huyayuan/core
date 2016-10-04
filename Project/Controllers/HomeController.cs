using Project.Biz;
using System;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            return new JsonResult()
            {
                Data = DataCache.Data[random.Next(0, DataCache.Data.Count - 1)],
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
