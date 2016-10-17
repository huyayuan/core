using Project.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return new JsonResult()
            {
                Data = DataCache.Data[GetPageIndex()],
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        private int GetPageIndex()
        {
            Random random = new Random();
            int newPageIndex;
            List<int> pageIndexList;
            var oldCookie = Request.Cookies["pageIndexList"];
            if (oldCookie != null)
            {
                try
                {
                    var oldPageIndexList = JsonConvert.DeserializeObject<List<int>>(oldCookie.Value);
                    var allPageIndexList = DataCache.Data.Keys.ToList();
                    var exceptPageIndex = allPageIndexList.Except(oldPageIndexList).ToList();
                    newPageIndex = exceptPageIndex[random.Next(0, exceptPageIndex.Count - 1)];
                    oldPageIndexList.Add(newPageIndex);
                    pageIndexList = oldPageIndexList;
                }
                catch (Exception)
                {
                    newPageIndex = random.Next(0, DataCache.Data.Count - 1);
                    pageIndexList = new List<int> {newPageIndex};
                }
            }
            else
            {
                newPageIndex = random.Next(0, DataCache.Data.Count - 1);
                pageIndexList = new List<int> {newPageIndex};
            }

            var cookieValue = JsonConvert.SerializeObject(pageIndexList);

            HttpCookie cookie = new HttpCookie("pageIndexList");
            cookie.Value = cookieValue;
            cookie.Expires = DateTime.Now.AddDays(100);
            HttpContext.Response.Cookies.Remove("pageIndexList");
            HttpContext.Response.SetCookie(cookie);
            return newPageIndex;
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
