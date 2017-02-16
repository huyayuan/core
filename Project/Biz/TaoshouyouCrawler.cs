using HtmlAgilityPack;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Project.Biz
{
    public class TaoshouyouCrawler:WebCrawler
    {
        public TaoshouyouCrawler(string url):base(url)
        {
        }

        public override List<AccountInfo> GetLastAccount(int count)
        {
            string htmlstr = GetHtmlStr(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlstr);
            HtmlNode rootnode = doc.DocumentNode;

            List<AccountInfo> accountList = new List<AccountInfo>();
            for (int index=1;index<=count;index++)
            {
                AccountInfo account = new AccountInfo();
                string titleXpath = string.Format(@"/html/body/div[2]/div[8]/div[3]/div[3]/div[{0}]/h1/a/span", index);
                string priceXpath = string.Format(@"/html/body/div[2]/div[8]/div[3]/div[3]/div[{0}]/div[2]/div/div", index);
                string urlXpath = string.Format(  @"/html/body/div[2]/div[8]/div[3]/div[3]/div[{0}]/h1/a", index);
                account.Title = rootnode.SelectSingleNode(titleXpath).InnerText.Trim().Substring(9);
                account.Fee = Convert.ToDouble(rootnode.SelectSingleNode(priceXpath).InnerText.Replace("￥", string.Empty));
                account.Link = "http://www.taoshouyou.com" + rootnode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                accountList.Add(account);
            }

            return accountList;
        }
    }
}
