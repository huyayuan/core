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
           var result = BoxListReader.GetData(HttpContext.Server.MapPath("~/Data/BoxList.csv"));

            return new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

       
    }
}
