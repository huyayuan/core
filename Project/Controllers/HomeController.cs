using Project.Biz;
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
            return new JsonResult()
            {
                Data = DataCache.Data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


    }
}
