using Project.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class DataCenterController : Controller
    {
        //
        // GET: /DataCenter/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public ActionResult Index(int? l = 200, int? h = 800, string f = "", string s = "", string t="")
        {
            var result = AccountInfoCache.CacheList.
                                          Where(a => (a.Fee >= l) && (a.Fee <= h)).
                                          Where(a=>a.Title.Contains(f) && a.Title.Contains(s) && a.Title.Contains(t)).
                                          OrderByDescending(a => a.Value).ToList();


            return View(result);


           // return new JsonResult()
            //{
                //Data = AccountInfoCache.CacheList.Where(t => (t.Fee >= l) && (t.Fee <= h)).OrderByDescending(t=>t.Value).ToList(),
                //JsonRequestBehavior = JsonRequestBehavior.AllowGet
           // };
        }
    }
}
