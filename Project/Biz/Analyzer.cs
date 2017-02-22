using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;

namespace Project.Biz
{
    public class Analyzer
    {
        static Dictionary<string, int> SSRCountDic = new Dictionary<string, int>();
        static Dictionary<string, SSR> SSRDic = new Dictionary<string, SSR>();
        static Dictionary<string, int> StarDic = new Dictionary<string, int>();
        static Analyzer()
        {
            SSRDic.Add("木", SSR.CiMu);
            SSRDic.Add("狗", SSR.TianGou);
            SSRDic.Add("刀", SSR.YaoDao);
            SSRDic.Add("鸟", SSR.Niao);
            SSRDic.Add("酒吞", SSR.JiuTun);
            SSRDic.Add("灯", SSR.Deng);
            SSRDic.Add("一目", SSR.YiMu);
            SSRDic.Add("川", SSR.Chuan);
            SSRDic.Add("鹿", SSR.Lu);
            SSRDic.Add("卷", SSR.Juan);

            StarDic.Add("6星", 6);
            StarDic.Add("六星", 6);
            StarDic.Add("6*", 6);
            StarDic.Add("6X", 6);
            StarDic.Add("6x", 6);
            StarDic.Add("5星", 5);
            StarDic.Add("五星", 5);
            StarDic.Add("5*", 5);
            StarDic.Add("5x", 5);
            StarDic.Add("5X", 5);

            SSRCountDic.Add("ssr", 1);
            SSRCountDic.Add("SSR", 1);

            SSRCountDic.Add("2个ssr", 2);
            SSRCountDic.Add("2个SSR", 2);
            SSRCountDic.Add("两个SSR", 2);
            SSRCountDic.Add("两个ssr", 2);
            SSRCountDic.Add("2ssr", 2);
            SSRCountDic.Add("2SSR", 2);
            SSRCountDic.Add("双ssr", 2);
            SSRCountDic.Add("双SSR", 2);
            SSRCountDic.Add("2s s r", 2);
            SSRCountDic.Add("2 ssr", 2);
            SSRCountDic.Add("2 SSR", 2);

            SSRCountDic.Add("3个ssr", 3);
            SSRCountDic.Add("3个SSR", 3);
            SSRCountDic.Add("3ssr", 3);
            SSRCountDic.Add("3SSR", 3);
            SSRCountDic.Add("三个ssr", 3);
            SSRCountDic.Add("三个SSR", 3);
            SSRCountDic.Add("三ssr", 3);
            SSRCountDic.Add("三SSR", 3);
            SSRCountDic.Add("3s s r", 3);
            SSRCountDic.Add("3 SSR", 3);
            SSRCountDic.Add("3 ssr", 3);

            SSRCountDic.Add("4个ssr", 4);
            SSRCountDic.Add("4个SSR", 4);
            SSRCountDic.Add("四个SSR", 4);
            SSRCountDic.Add("四个ssr", 4);
            SSRCountDic.Add("4ssr", 4);
            SSRCountDic.Add("4SSR", 4);
            SSRCountDic.Add("四ssr", 4);
            SSRCountDic.Add("四SSR", 4);
            SSRCountDic.Add("4s s r", 4);
            SSRCountDic.Add("4 ssr", 4);
            SSRCountDic.Add("4 SSR", 4);

            SSRCountDic.Add("5SSR", 5);
            SSRCountDic.Add("5ssr", 5);
            SSRCountDic.Add("五个SSR", 5);
            SSRCountDic.Add("五个ssr", 5);
            SSRCountDic.Add("五SSR", 5);
            SSRCountDic.Add("五ssr", 5);
            SSRCountDic.Add("5个ssr", 5);
            SSRCountDic.Add("5个SSR", 5);
            SSRCountDic.Add("5s s r", 5);
            SSRCountDic.Add("5 SSR", 5);
            SSRCountDic.Add("5 ssr", 5);

            SSRCountDic.Add("6个ssr", 6);
            SSRCountDic.Add("6个SSR", 6);
            SSRCountDic.Add("6SSR", 6);
            SSRCountDic.Add("6ssr", 6);
            SSRCountDic.Add("六个SSR", 6);
            SSRCountDic.Add("六个ssr", 6);
            SSRCountDic.Add("六SSR", 6);
            SSRCountDic.Add("六ssr", 6);
            SSRCountDic.Add("6s s r", 6);
            SSRCountDic.Add("6 ssr", 6);
            SSRCountDic.Add("6 SSR", 6);

            SSRCountDic.Add("7个ssr", 7);
            SSRCountDic.Add("7个SSR", 7);
            SSRCountDic.Add("7SSR", 7);
            SSRCountDic.Add("7ssr", 7);
            SSRCountDic.Add("七个SSR", 7);
            SSRCountDic.Add("七个ssr", 7);
            SSRCountDic.Add("七ssr", 7);
            SSRCountDic.Add("七SSR", 7);
            SSRCountDic.Add("7s s r", 7);
            SSRCountDic.Add("7 SSR", 7);
            SSRCountDic.Add("7 ssr", 7);

            SSRCountDic.Add("8个ssr", 8);
            SSRCountDic.Add("8个SSR", 8);
            SSRCountDic.Add("八个SSR", 8);
            SSRCountDic.Add("八个ssr", 8);
            SSRCountDic.Add("8ssr", 8);
            SSRCountDic.Add("8SSR", 8);
            SSRCountDic.Add("八ssr", 8);
            SSRCountDic.Add("八SSR", 8);
            SSRCountDic.Add("8s s r", 8);
            SSRCountDic.Add("8 SSR", 8);
            SSRCountDic.Add("8 ssr", 8);

            SSRCountDic.Add("9个ssr", 9);
            SSRCountDic.Add("9个SSR", 9);
            SSRCountDic.Add("九个SSR", 9);
            SSRCountDic.Add("九个ssr", 9);
            SSRCountDic.Add("9ssr", 9);
            SSRCountDic.Add("9SSR", 9);
            SSRCountDic.Add("九ssr", 9);
            SSRCountDic.Add("九SSR", 9);
            SSRCountDic.Add("9s s r", 9);
            SSRCountDic.Add("9 ssr", 9);
            SSRCountDic.Add("9 SSR", 9);

            SSRCountDic.Add("10个ssr", 10);
            SSRCountDic.Add("10个SSR", 10);
            SSRCountDic.Add("十个SSR", 10);
            SSRCountDic.Add("十个ssr", 10);
            SSRCountDic.Add("十SSR", 10);
            SSRCountDic.Add("十ssr", 10);
            SSRCountDic.Add("10ssr", 10);
            SSRCountDic.Add("10SSR", 10);
            SSRCountDic.Add("10s s r", 10);
            SSRCountDic.Add("10 SSR", 10);
            SSRCountDic.Add("10 ssr", 10);

            SSRCountDic.Add("11个ssr", 11);
            SSRCountDic.Add("11个SSR", 11);
            SSRCountDic.Add("十一个SSR", 11);
            SSRCountDic.Add("十一个ssr", 11);
            SSRCountDic.Add("十一SSR", 11);
            SSRCountDic.Add("十一ssr", 11);
            SSRCountDic.Add("11ssr", 11);
            SSRCountDic.Add("11SSR", 11);
            SSRCountDic.Add("11s s r", 11);
            SSRCountDic.Add("11 SSR", 11);
            SSRCountDic.Add("11 ssr", 11);
        }


        public List<AccountInfo> FilterAccountInfo(List<AccountInfo> accountList)
        {
            Init(accountList);
            return FilterByRules(accountList);
        }

        private List<AccountInfo> FilterByRules(List<AccountInfo> accountList)
        {
            var result = new List<AccountInfo>();
            var temp = accountList.Where(t => t.Fee > 15 && t.Fee < 350).ToList();
            foreach(var item in temp)
            {
                #region Rules
                if (item.Fee < 120 && item.SRRCount >= 3)
                {
                    result.Add(item);
                    continue;
                }

                //有萌新
                if (item.Fee <= 151 && item.Fee > 0 && (item.Title.Contains("账号") || item.Title.Contains("阴阳师")))
                {
                    result.Add(item);
                    continue;
                }

                if (item.Fee <= 170 && item.SRRCount >= 4)
                {
                    result.Add(item);
                    continue;
                }

                //小于200, 5ssr
                if (item.Fee <= 220 && item.SRRCount >= 5)
                {
                    result.Add(item);
                    continue;
                }

                //小于300, 6ssr
                if (item.Fee <= 270 && item.SRRCount >= 6)
                {
                    result.Add(item);
                    continue;
                }

                if (item.Fee <= 350 && item.SRRCount >= 7)
                {
                    result.Add(item);
                    continue;
                }

                //小于100,20级茨木
                if (item.Fee <= 110 && item.SSRList.Contains(SSR.CiMu) && item.Level > 20)
                {
                    result.Add(item);
                    continue;
                }

                //小于200，茨木妖刀
                if (item.Fee <= 210 && item.SSRList.Contains(SSR.CiMu) && item.SSRList.Contains(SSR.YaoDao))
                {
                    result.Add(item);
                    continue;
                }

                //小于200，茨木天狗
                if (item.Fee <= 210 && item.SSRList.Contains(SSR.CiMu) && item.SSRList.Contains(SSR.TianGou))
                {
                    result.Add(item);
                    continue;
                }

                //小于150，天狗妖刀
                if (item.Fee <= 170 && item.SSRList.Contains(SSR.TianGou) && item.SSRList.Contains(SSR.YaoDao))
                {
                    result.Add(item);
                    continue;
                }

                //小于170,6星天狗或者妖刀
                if (item.Fee <= 190 && item.Star == 6 && (item.SSRList.Contains(SSR.TianGou) || item.SSRList.Contains(SSR.YaoDao)))
                {
                    result.Add(item);
                    continue;
                }

                //小于150,6星
                if (item.Fee <= 170 && item.Star == 6)
                {
                    result.Add(item);
                    continue;
                }

                //小于300,6星次木
                if (item.Fee <= 250 && item.Star == 6 && item.SSRList.Contains(SSR.CiMu))
                {
                    result.Add(item);
                    continue;
                }

                //小于100,5星茨木或者天狗或者妖刀
                if (item.Fee <= 100 && item.Star == 5 && (item.SSRList.Contains(SSR.CiMu) || item.SSRList.Contains(SSR.TianGou) || item.SSRList.Contains(SSR.YaoDao)))
                {
                    result.Add(item);
                    continue;
                }

                if (item.Fee <= 300 && (item.SSRList.Contains(SSR.CiMu) && item.SSRList.Contains(SSR.TianGou) && item.SSRList.Contains(SSR.YaoDao)))
                {
                    result.Add(item);
                    continue;
                }
                #endregion
            }
            return result;
        }

        private static void Init(List<AccountInfo> accountList)
        {
            foreach (var account in accountList)
            {
                account.Title = account.Title.Replace("准六", "五星");
                account.Title = account.Title.Replace("准6", "五星");
                account.Title = account.Title.Replace("半6", "五星");
                account.Title = account.Title.Replace("半六", "五星");

                if(account.Title.Contains("级】"))
                {
                    account.Level = Convert.ToInt32(account.Title.Substring(1, account.Title.IndexOf("级") - 1));
                }

                foreach (var item in SSRCountDic)
                {
                    if (account.Title.Contains(item.Key))
                    {
                        account.SRRCount = item.Value;
                    }
                }

                account.SSRList = new List<SSR>();
                foreach (var item in SSRDic)
                {
                    if (account.Title.Contains(item.Key))
                    {
                        account.SSRList.Add(item.Value);
                    }
                }

                foreach (var item in StarDic)
                {
                    if (account.Title.Contains(item.Key) && account.Star < item.Value)
                    {
                        account.Star = item.Value;
                    }
                }
            }
        }
    }
}