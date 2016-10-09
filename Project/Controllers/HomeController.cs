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
            var dataIndex = random.Next(0, DataCache.Data.Count - 1);
            return new JsonResult()
            {
                Data = DataCache.Data[dataIndex],
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
