using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using Project.Models;

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
            var data = System.IO.File.ReadAllText(HttpContext.Server.MapPath("~/Data/BoxList.json"));

            return new JsonResult()
            {
                Data = JsonConvert.DeserializeObject<List<Box>>(data),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
