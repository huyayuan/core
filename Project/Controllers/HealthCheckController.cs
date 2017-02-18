using Project.Biz;
using Project.Biz.DataCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HealthCheckController : Controller
    {
        public ActionResult Index()
        {
            return new JsonResult()
            {
                Data = HealthCache.LastHeartBeatTime.ToString("yyyy-MM-dd HH:mm:ss"),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
