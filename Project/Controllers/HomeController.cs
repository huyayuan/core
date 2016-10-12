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

        [HttpPost]
        public ActionResult Feedback(Feedback feedback)
        {
            System.IO.File.AppendAllText(HttpContext.Server.MapPath("~/Database/Feedback.txt"), string.Format("user:{0} | comment:{1} \n", feedback.Contact, feedback.Comment));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetFeedback()
        {
            return new JsonResult()
            {
                Data =
                    System.IO.File.ReadAllText(
                        HttpContext.Server.MapPath("~/Database/Feedback.txt")),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }


    public class Feedback
    {
        public string Contact { get; set; }

        public string Comment { get; set; }
    }
}
