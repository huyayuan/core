using Project.Biz;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        private const int DataCountPerPage = 13;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var filesName = Directory.EnumerateFiles(HttpContext.Current.Server.MapPath("~/Data/")).OrderBy(t=>t);
            List<Box> allData = new List<Box>();
            foreach (var fileName in filesName)
            {
                allData.AddRange(BoxListReader.GetData(fileName));
            }

            for(int index=0;index < allData.Count / DataCountPerPage; index++)
            {
                var data = allData.Skip(index * DataCountPerPage).Take(DataCountPerPage).OrderBy(t => t.Rate).ToList();
                data.ForEach(d => d.Id = Guid.NewGuid().ToString());
                DataCache.Data.Add(index, data);
            }
        }
    }
}