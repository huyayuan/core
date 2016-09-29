using System.Collections.Generic;
using System.Web.Mvc;
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
            var result = new List<Box>
            {
                new Box()
                {
                    Title =
                        "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit ...",
                    Url = "Content/Images/img_lights.jpg",
                    Rate = "3.4万"
                },
                new Box()
                {
                    Title =
                        "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit ...",
                    Url = "Content/Images/img_lights.jpg",
                    Rate = "3.4万"
                },
                new Box()
                {
                    Title =
                        "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit ...",
                    Url = "Content/Images/img_lights.jpg",
                    Rate = "3.4万"
                },
            };


            return new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
