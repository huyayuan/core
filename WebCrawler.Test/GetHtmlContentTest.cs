using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Project.Biz;
using System.Net;

namespace Web.Test
{
    [TestClass]
    public class GetHtmlContentTest
    {
        [TestMethod]
        public void GetHtmlContent()
        {
            WebCrawler webCrawler = new WebCrawler("http://m.jiaoyimao.com/g4308-c1/r1.html?1477379608309687=%E6%9C%AA%E8%AE%A4%E8%AF%81%E8%BA%AB%E4%BB%BD%E8%AF%81&1478241856106497=%E7%BD%91%E6%98%93%E9%82%AE%E7%AE%B1%E5%B8%90%E5%8F%B7");
            var result = webCrawler.GetLastAccount(10);
        }

        [TestMethod]
        public void SendEmail()
        {
            WebCrawler webCrawler = new WebCrawler("http://m.jiaoyimao.com/g4308-c1/r1.html?1477379608309687=%E6%9C%AA%E8%AE%A4%E8%AF%81%E8%BA%AB%E4%BB%BD%E8%AF%81&1478241856106497=%E7%BD%91%E6%98%93%E9%82%AE%E7%AE%B1%E5%B8%90%E5%8F%B7");
            var result = webCrawler.GetLastAccount(10);
            var content = string.Format("<a href='{2}' target='_blank'> {0}￥ —— {1} </a> ", result.FirstOrDefault().Fee, result.FirstOrDefault().Title, result.FirstOrDefault().Link);
            webCrawler.SendEmail( "test",content);
        }

        [TestMethod]
        public void GetTaoshouyou()
        {
            //WebClient client = new WebClient();
            //client.Encoding = System.Text.Encoding.UTF8;
            //string result = client.DownloadString("http://m.jiaoyimao.com/g4308/r1.html?lowerPrice=0&higherPrice=350&1477379583923047=10%E4%BB%A5%E4%B8%8A&1477379608309687=%E6%9C%AA%E8%AE%A4%E8%AF%81%E8%BA%AB%E4%BB%BD%E8%AF%81&1478241856106497=%E7%BD%91%E6%98%93%E9%82%AE%E7%AE%B1%E5%B8%90%E5%8F%B7");


            ////WebCrawler webCrawler = new TaoshouyouCrawler("http://www.taoshouyou.com/game/yinyangshi-3894-20-1/0-0-1-9-0-0-0-0-0-0-2-0-1?quotaid=0");
            ////var result = webCrawler.GetLastAccount(10);

            ////result = new Analyzer().FilterAccountInfo(result);

            var test = "http://m.jiaoyimao.com/goods/1487760590441819.html";
            var result = test.Split('/').Last().Replace(".html", string.Empty);

        }


    }
}
