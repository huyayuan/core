using Project.Biz;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        private static readonly WebCrawler crawler = new WebCrawler("http://m.jiaoyimao.com/g4308-c1472811121511870/r1.html?lowerPrice=0&higherPrice=400&1477379608309687=%E6%9C%AA%E8%AE%A4%E8%AF%81%E8%BA%AB%E4%BB%BD%E8%AF%81&1478241856106497=%E7%BD%91%E6%98%93%E9%82%AE%E7%AE%B1%E5%B8%90%E5%8F%B7");
        private static readonly WebCrawler taoshouyouCrawler = new TaoshouyouCrawler("http://www.taoshouyou.com/game/yinyangshi-3894-20-1/0-0-1-9-0-0-0-0-0-0-2-0-1?quotaid=0");

        private static readonly Analyzer analyzer = new Analyzer();
        private static List<string> LastRecords = new List<string>();
        private static Random rd = new Random();


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CreateDataCache();
            GetAccountInfo();
        }

        private void GetAccountInfo()
        {
            Task.Factory.StartNew(jiaoyimao);
            //Task.Factory.StartNew(taoshouyou);
        }

        public void jiaoyimao()
        {
            while (true)
            {
                try
                {
                    var result = crawler.GetLastAccount(13);
                    result = analyzer.FilterAccountInfo(result);

                    if (result.Count > 0)
                    {
                        StringBuilder builder = new StringBuilder();
                        foreach (var item in result)
                        {
                            if (LastRecords.Contains(item.Link))
                            {
                                continue;
                            }

                            builder.Append(string.Format("<a href='{2}' target='_blank'> {0}￥ —— {1} </a> ", item.Fee, item.Title, item.Link));
                            builder.Append("<br/>");
                        }

                        if (!string.IsNullOrWhiteSpace(builder.ToString()))
                        {
                            crawler.SendEmail(result.First().Title, builder.ToString());
                            LastRecords = result.Select(t => t.Link).ToList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        crawler.SendEmail("error", ex.ToString() + "<br/>stack trace" + ex.StackTrace);
                    }
                    catch
                    {
                        continue;
                    }
                }

                Thread.Sleep(1000);
            }
        }
        public void taoshouyou()
        {
            while (true)
            {
                try
                {
                    var result = taoshouyouCrawler.GetLastAccount(13);
                    result = analyzer.FilterAccountInfo(result);

                    if (result.Count > 0)
                    {
                        StringBuilder builder = new StringBuilder();
                        foreach (var item in result)
                        {
                            if (LastRecords.Contains(item.Link))
                            {
                                continue;
                            }

                            builder.Append(string.Format("<a href='{2}' target='_blank'> {0}￥ —— {1} </a> ", item.Fee, item.Title, item.Link));
                            builder.Append("<br/>");
                        }

                        if (!string.IsNullOrWhiteSpace(builder.ToString()))
                        {
                            crawler.SendEmail(result.First().Title, builder.ToString());
                            LastRecords = result.Select(t => t.Link).ToList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        crawler.SendEmail("error", ex.ToString() + "<br/>stack trace" + ex.StackTrace);
                    }
                    catch
                    {
                        continue;
                    }
                }

                Thread.Sleep(5000);
            }
        }

        private static void CreatAccountInfoCache()
        {
            var dataPath = HttpContext.Current.Server.MapPath("~/DataCenter/");
            var filesName = Directory.EnumerateFiles(dataPath).OrderByDescending(t => t);
            List<AccountInfo> allData = new List<AccountInfo>();
            foreach (var fileName in filesName)
            {
                allData.AddRange(AccountInfoReader.GetData(fileName));
            }

            AccountInfoCache.CacheList = allData;
        }

        private static void CreateDataCache()
        {
            var dataPath = HttpContext.Current.Server.MapPath("~/Data/");
            var filesName = Directory.EnumerateFiles(HttpContext.Current.Server.MapPath("~/Data/")).OrderByDescending(t => t);
            List<Box> allData = new List<Box>();
            foreach (var fileName in filesName)
            {
                allData.AddRange(BoxListReader.GetData(fileName));
            }

            for (int index = 0; index < allData.Count / DataCountPerPage; index++)
            {
                var data = allData.Skip(index * DataCountPerPage).Take(DataCountPerPage).OrderBy(t => t.Rate).ToList();
                data.ForEach(d => d.Id = Guid.NewGuid().ToString());
                DataCache.Data.Add(index, data);
            }
        }
    }
}