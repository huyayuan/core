using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    public class WebCrawler
    {
        private string url;

        public WebCrawler(string url)
        {
            this.url = url;
        }

        private static string GetHtmlStr(string url)
        {
            try
            {
                WebRequest rGet = WebRequest.Create(url);
                WebResponse rSet = rGet.GetResponse();
                Stream s = rSet.GetResponseStream();
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                return reader.ReadToEnd();
            }
            catch (WebException)
            {
                //连接失败
                return null;
            }
        }

        public List<Account> GetLastAccount(int count)
        {
            string htmlstr = GetHtmlStr(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlstr);
            HtmlNode rootnode = doc.DocumentNode;

            List<Account> accountList = new List<Account>();
            for (int index=1;index<=count;index++)
            {
                Account account = new Account();
                string titleXpath = string.Format( @"/html/body/div[5]/dl/dd[{0}]/a/span[1]", index);
                string priceXpath = string.Format(@"/html/body/div[5]/dl/dd[{0}]/a/em", index);
                string urlXpath = string.Format(@"/html/body/div[5]/dl/dd[{0}]/a", index);

                string levelXpath = string.Format(@"/html/body/div[5]/dl/dd[{0}]/a/div/div[1]", index);
                var levelNodes = rootnode.SelectSingleNode(levelXpath).ChildNodes;
                if (levelNodes.Count > 3 && levelNodes.First().Attributes.Any() && levelNodes.First().Attributes["class"].Value != "level-1")
                {
                    continue;
                }

                account.Title = rootnode.SelectSingleNode(titleXpath).InnerText.Trim();
                account.Price = Convert.ToDouble(rootnode.SelectSingleNode(priceXpath).InnerText.Replace("￥", string.Empty));
                account.Url = rootnode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                accountList.Add(account);
            }

            return accountList;
        }

        public void SendEmail(string content)
        {
            var emailAcount = "huyayuanme@163.com";
            var emailPassword = "dxfjiangnan";
            var reciver = "huyayuanme@163.com";
            MailMessage message = new MailMessage();
            //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
            MailAddress fromAddr = new MailAddress(emailAcount);
            message.From = fromAddr;
            message.SubjectEncoding = Encoding.UTF8;
            message.BodyEncoding = Encoding.UTF8;
            message.Priority = MailPriority.High;
            //设置收件人,可添加多个,添加方法与下面的一样
            message.To.Add(reciver);
            message.IsBodyHtml = true;
            //设置邮件标题
            message.Subject = "交易猫";
            //设置邮件内容
            message.Body = content;
            //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的
            SmtpClient client = new SmtpClient("smtp.163.com", 25);
            //设置发送人的邮箱账号和密码
            client.Credentials = new NetworkCredential(emailAcount, emailPassword);
            //启用ssl,也就是安全发送
            //client.EnableSsl = true;
            //发送邮件
            client.Send(message);
        }
    }
}
