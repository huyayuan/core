using Project.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Project
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DataCache.Data.Add(0, BoxListReader.GetData(HttpContext.Current.Server.MapPath("~/Data/BoxList20161002.csv")));
            DataCache.Data.Add(1, BoxListReader.GetData(HttpContext.Current.Server.MapPath("~/Data/BoxList20161003.csv")));
            DataCache.Data.Add(2, BoxListReader.GetData(HttpContext.Current.Server.MapPath("~/Data/BoxList20161004.csv")));
        }
    }
}