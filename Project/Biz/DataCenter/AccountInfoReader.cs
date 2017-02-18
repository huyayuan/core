using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Project.Biz
{
    public class AccountInfoReader
    {
        static Dictionary<string, double> heroDic = new Dictionary<string, double>();
        static int ErrorCount = 0;

        static Dictionary<string, SSRCount> SSRDic = new Dictionary<string, SSRCount>();
        static Dictionary<string, double> StarDic = new Dictionary<string, double>();

        static AccountInfoReader()
        {
            heroDic.Add("茨木", 4);
            heroDic.Add("次木", 4);
            heroDic.Add("狗", 3);
            heroDic.Add("刀", 2);
            heroDic.Add("鸟", 1);
            heroDic.Add("酒吞", 1);
            heroDic.Add("灯", 1);
            heroDic.Add("一目", 1);
            heroDic.Add("皮", 1);
            heroDic.Add("荒川", 1);
            heroDic.Add("鹿", 1);
            heroDic.Add("花鸟卷", 1);
            heroDic.Add("欧", 4);
            heroDic.Add("魔", 1);

            StarDic.Add("6星", 6);
            StarDic.Add("六星", 6);
            StarDic.Add("6*", 6);
            StarDic.Add("6X", 6);
            StarDic.Add("6x", 6);
            StarDic.Add("5星", 2);
            StarDic.Add("五星", 2);
            StarDic.Add("5*", 2);

            SSRDic.Add("ssr", SSRCount.SSR1);
            SSRDic.Add("SSR", SSRCount.SSR1);

            SSRDic.Add("2个ssr", SSRCount.SSR2);
            SSRDic.Add("2个SSR", SSRCount.SSR2);
            SSRDic.Add("两个SSR", SSRCount.SSR2);
            SSRDic.Add("两个ssr", SSRCount.SSR2);
            SSRDic.Add("2ssr", SSRCount.SSR2);
            SSRDic.Add("2SSR", SSRCount.SSR2);
            SSRDic.Add("双ssr", SSRCount.SSR2);
            SSRDic.Add("双SSR", SSRCount.SSR2);
            SSRDic.Add("2s s r", SSRCount.SSR2);
            SSRDic.Add("2 ssr", SSRCount.SSR2);
            SSRDic.Add("2 SSR", SSRCount.SSR2);

            SSRDic.Add("3个ssr", SSRCount.Three);
            SSRDic.Add("3个SSR", SSRCount.Three);
            SSRDic.Add("3ssr", SSRCount.Three);
            SSRDic.Add("3SSR", SSRCount.Three);
            SSRDic.Add("三个ssr", SSRCount.Three);
            SSRDic.Add("三个SSR", SSRCount.Three);
            SSRDic.Add("三ssr", SSRCount.Three);
            SSRDic.Add("三SSR", SSRCount.Three);
            SSRDic.Add("3s s r", SSRCount.Three);
            SSRDic.Add("3 SSR", SSRCount.Three);
            SSRDic.Add("3 ssr", SSRCount.Three);

            SSRDic.Add("4个ssr", SSRCount.Four);
            SSRDic.Add("4个SSR", SSRCount.Four);
            SSRDic.Add("四个SSR", SSRCount.Four);
            SSRDic.Add("四个ssr", SSRCount.Four);
            SSRDic.Add("4ssr", SSRCount.Four);
            SSRDic.Add("4SSR", SSRCount.Four);
            SSRDic.Add("四ssr", SSRCount.Four);
            SSRDic.Add("四SSR", SSRCount.Four);
            SSRDic.Add("4s s r", SSRCount.Four);
            SSRDic.Add("4 ssr", SSRCount.Four);
            SSRDic.Add("4 SSR", SSRCount.Four);

            SSRDic.Add("5SSR", SSRCount.Five);
            SSRDic.Add("5ssr", SSRCount.Five);
            SSRDic.Add("五个SSR", SSRCount.Five);
            SSRDic.Add("五个ssr", SSRCount.Five);
            SSRDic.Add("五SSR", SSRCount.Five);
            SSRDic.Add("五ssr", SSRCount.Five);
            SSRDic.Add("5个ssr", SSRCount.Five);
            SSRDic.Add("5个SSR", SSRCount.Five);
            SSRDic.Add("5s s r", SSRCount.Five);
            SSRDic.Add("5 SSR", SSRCount.Five);
            SSRDic.Add("5 ssr", SSRCount.Five);

            SSRDic.Add("6个ssr", SSRCount.Six);
            SSRDic.Add("6个SSR", SSRCount.Six);
            SSRDic.Add("6SSR", SSRCount.Six);
            SSRDic.Add("6ssr", SSRCount.Six);
            SSRDic.Add("六个SSR", SSRCount.Six);
            SSRDic.Add("六个ssr", SSRCount.Six);
            SSRDic.Add("六SSR", SSRCount.Six);
            SSRDic.Add("六ssr", SSRCount.Six);
            SSRDic.Add("6s s r", SSRCount.Six);
            SSRDic.Add("6 ssr", SSRCount.Six);
            SSRDic.Add("6 SSR", SSRCount.Six);

            SSRDic.Add("7个ssr", SSRCount.Seven);
            SSRDic.Add("7个SSR", SSRCount.Seven);
            SSRDic.Add("7SSR", SSRCount.Seven);
            SSRDic.Add("7ssr", SSRCount.Seven);
            SSRDic.Add("七个SSR", SSRCount.Seven);
            SSRDic.Add("七个ssr", SSRCount.Seven);
            SSRDic.Add("七ssr", SSRCount.Seven);
            SSRDic.Add("七SSR", SSRCount.Seven);
            SSRDic.Add("7s s r", SSRCount.Seven);
            SSRDic.Add("7 SSR", SSRCount.Seven);
            SSRDic.Add("7 ssr", SSRCount.Seven);

            SSRDic.Add("8个ssr", SSRCount.Eight);
            SSRDic.Add("8个SSR", SSRCount.Eight);
            SSRDic.Add("八个SSR", SSRCount.Eight);
            SSRDic.Add("八个ssr", SSRCount.Eight);
            SSRDic.Add("8ssr", SSRCount.Eight);
            SSRDic.Add("8SSR", SSRCount.Eight);
            SSRDic.Add("八ssr", SSRCount.Eight);
            SSRDic.Add("八SSR", SSRCount.Eight);
            SSRDic.Add("8s s r", SSRCount.Eight);
            SSRDic.Add("8 SSR", SSRCount.Eight);
            SSRDic.Add("8 ssr", SSRCount.Eight);

            SSRDic.Add("9个ssr", SSRCount.Nine);
            SSRDic.Add("9个SSR", SSRCount.Nine);
            SSRDic.Add("九个SSR", SSRCount.Nine);
            SSRDic.Add("九个ssr", SSRCount.Nine);
            SSRDic.Add("9ssr", SSRCount.Nine);
            SSRDic.Add("9SSR", SSRCount.Nine);
            SSRDic.Add("九ssr", SSRCount.Nine);
            SSRDic.Add("九SSR", SSRCount.Nine);
            SSRDic.Add("9s s r", SSRCount.Nine);
            SSRDic.Add("9 ssr", SSRCount.Nine);
            SSRDic.Add("9 SSR", SSRCount.Nine);

            SSRDic.Add("10个ssr", SSRCount.Ten);
            SSRDic.Add("10个SSR", SSRCount.Ten);
            SSRDic.Add("十个SSR", SSRCount.Ten);
            SSRDic.Add("十个ssr", SSRCount.Ten);
            SSRDic.Add("十SSR", SSRCount.Ten);
            SSRDic.Add("十ssr", SSRCount.Ten);
            SSRDic.Add("10ssr", SSRCount.Ten);
            SSRDic.Add("10SSR", SSRCount.Ten);
            SSRDic.Add("10s s r", SSRCount.Ten);
            SSRDic.Add("10 SSR", SSRCount.Ten);
            SSRDic.Add("10 ssr", SSRCount.Ten);

            SSRDic.Add("11个ssr", SSRCount.SSR11);
            SSRDic.Add("11个SSR", SSRCount.SSR11);
            SSRDic.Add("十一个SSR", SSRCount.SSR11);
            SSRDic.Add("十一个ssr", SSRCount.SSR11);
            SSRDic.Add("十一SSR", SSRCount.SSR11);
            SSRDic.Add("十一ssr", SSRCount.SSR11);
            SSRDic.Add("11ssr", SSRCount.SSR11);
            SSRDic.Add("11SSR", SSRCount.SSR11);
            SSRDic.Add("11s s r", SSRCount.SSR11);
            SSRDic.Add("11 SSR", SSRCount.SSR11);
            SSRDic.Add("11 ssr", SSRCount.SSR11);
        }

        public static List<AccountInfo> GetData(string filePath)
        {
            List<AccountInfo> result = new List<AccountInfo>();
            
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936)))
            {
                sr.ReadLine();
                string str = sr.ReadLine();
                while (str != null)
                {
                    try
                    {
                        string[] dataList = str.Split(',');

                        AccountInfo info = new AccountInfo()
                        {
                            Link = RemoveQuotes(dataList[0]),
                            Title = RemoveQuotes(dataList[1]),
                            Fee = Convert.ToDouble(RemoveQuotes(dataList[2])),
                        };

                        result.Add(info);
                        str = sr.ReadLine();
                    }
                    catch(Exception)
                    {
                        ErrorCount++;
                        str = sr.ReadLine();
                    }
                }

                sr.Close();
            }

            result.ForEach(info =>
            {
                CalculateInfoValue(info);
            });

            return result;
        }

        private static void CalculateInfoValue(AccountInfo info)
        {
            info.Value = GetSSRPoint(info);
        }

        private static double GetSSRPoint(AccountInfo info)
        {
            string title = info.Title;
            title = title.Replace("准六", "五星");
            title = title.Replace("准6", "五星");
            title = title.Replace("半6", "五星");
            title = title.Replace("半六", "五星");

            var test = title.Substring(1, title.IndexOf("级") - 1);
            double levelPoint = Convert.ToInt32(test) / 20;
            return levelPoint + CalculateDescription(title, info);
        }

        private static double CalculateDescription(string description, AccountInfo info)
        {
            double sumPoint = 0;

            foreach (var item in SSRDic)
            {
                if (description.Contains(item.Key))
                {
                    sumPoint += (int)item.Value;
                    //info.SRRCount = item.Value;
                }
            }

            foreach (var item in StarDic)
            {
                if (description.Contains(item.Key))
                {
                    sumPoint += item.Value;
                }
            }

            foreach (var item in heroDic)
            {
                if (description.Contains(item.Key))
                {
                    sumPoint += item.Value;
                }
            }

            if(description.Contains("狗") && description.Contains("木") && description.Contains("刀"))
            {
                sumPoint += 7;
            }

            return sumPoint;
        }

        private static string RemoveQuotes(string original)
        {
            if (original.Length == 1)
            {
                return original;
            }

            if (string.IsNullOrWhiteSpace(original))
            {
                return string.Empty;
            }

            return original.Substring(1, original.Length - 2);
        }
    }
}