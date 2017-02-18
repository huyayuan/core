using Project.Biz;
using Project.Biz.DataCenter;
using Project.Models.DataCenter;
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
                Data = new HealthCheckDto()
                {
                    LastHeartBeatTime = HealthCache.LastHeartBeatTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    LastEmailSentTime = HealthCache.LastEmailSentTime.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
