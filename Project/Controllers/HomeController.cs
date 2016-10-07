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
        
        public ActionResult GetData(int index = 0)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            index = index % DataCache.Data.Count;
            return new JsonResult()
            {
                Data = DataCache.Data[index],
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
