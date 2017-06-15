using HtmlAgilityPack;
using Project.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Project.Biz
{
    public class WebCrawler
    {
        protected string url;

        private string lastTitle;

        protected WebClient client;

        public WebCrawler(string url)
        {
            this.url = url;
            client = new WebClient();
            client.Encoding = Encoding.UTF8;
        }

        protected string GetHtmlStr(string url)
        {
            return client.DownloadString(url);
        }

        public virtual List<AccountInfo> GetLastAccount(int count)
        {
            List<AccountInfo> accountList = new List<AccountInfo>();
            string htmlstr = GetHtmlStr(url);
            if(string.IsNullOrWhiteSpace(htmlstr))
            {
                return accountList;
            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlstr);
            HtmlNode rootnode = doc.DocumentNode;

            for (int index=1;index<=count;index++)
            {
                AccountInfo account = new AccountInfo();
                string titleXpath = string.Format(@"//*[@id='goodsList']/li[{0}]/a/div/div[1]", index);
                string priceXpath = string.Format(@"//*[@id='goodsList']/li[{0}]/a/div/div[5]", index);
                string urlXpath = string.Format(@"//*[@id='goodsList']/li[{0}]/a", index);
                account.Title = rootnode.SelectSingleNode(titleXpath).InnerText.Trim();
                if(rootnode.SelectSingleNode(priceXpath) != null && !string.IsNullOrWhiteSpace(rootnode.SelectSingleNode(priceXpath).InnerText))
                {
                    account.Fee = Convert.ToDouble(rootnode.SelectSingleNode(priceXpath).InnerText.Replace("￥", string.Empty));
                }

                account.Link = rootnode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                account.BuyLink = string.Format("https://m.jiaoyimao.com/buyer/{0}/waitPay", account.Link.Split('/').Last().Replace(".html", string.Empty));

                accountList.Add(account);
            }

            return accountList;
        }

        //public void SendEmail(string title, string content)
        //{
        //    var emailAcount = "flowerdanceer@gmail.com";
        //    var emailPassword = "huyayuan";
        //    var reciver = "yayuanzhanghao@163.com";
        //    MailMessage message = new MailMessage();
        //    //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
        //    MailAddress fromAddr = new MailAddress(emailAcount);
        //    message.From = fromAddr;
        //    //message.SubjectEncoding = Encoding.UTF8;
        //    //message.BodyEncoding = Encoding.UTF8;
        //    message.Priority = MailPriority.High;
        //    //设置收件人,可添加多个,添加方法与下面的一样
        //    message.To.Add(reciver);
        //    message.IsBodyHtml = true;
        //    //设置邮件标题
        //    message.Subject = title;
        //    //设置邮件内容
        //    message.Body = content;
        //    //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的
        //    //SmtpClient client = new SmtpClient("smtp.163.com", 25);
        //    ////设置发送人的邮箱账号和密码
        //    //client.UseDefaultCredentials = false;
        //    //client.Credentials = new NetworkCredential(emailAcount, emailPassword);
        //    //client.EnableSsl = true;
        //    ////启用ssl,也就是安全发送
        //    //client.EnableSsl = true;
        //    ////发送邮件

        //    var client = new SmtpClient("smtp.gmail.com", 587)
        //    {
        //        UseDefaultCredentials = false,
        //        EnableSsl = true,
        //        Timeout = 5000,
        //        Credentials = new NetworkCredential("flowerdanceer@gmail.com", "huyayuan", "")  // gmailid is someguy@gmail.com
        //    };

        //    client.Send(message);
        //}

        public void SendEmail(string title, string content)
        {
            if(lastTitle == title)
            {
                return;
            }

            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("flowerdanceer@gmail.com", "YY");
            var to = new EmailAddress("huyayuanme@163.com", "HH");
            var htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from, to, title, "", htmlContent);
            var response = client.SendEmailAsync(msg).Result;
            lastTitle = title;
        }
    }
}
