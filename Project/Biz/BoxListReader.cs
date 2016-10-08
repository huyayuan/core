using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Project.Biz
{
    public class BoxListReader
    {
        public static List<Box> GetData(string filePath)
        {
            List<Box> result = new List<Box>();
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936)))
            {
                sr.ReadLine();
                int index = 0;
                string str = sr.ReadLine();
                while (str != null)
                {
                    string[] dataList = str.Split(',');

                    Box box = new Box()
                    {
                        Type = BoxType.Image,
                        Id = index++.ToString(),
                        Title = RemoveQuotes(dataList[0]),
                        Comments = RemoveQuotes(dataList[1]),
                        Rate = RemoveQuotes(dataList[2]),
                        Url = RemoveQuotes(dataList[3])
                    };

                    result.Add(box);
                    str = sr.ReadLine();
                }

                sr.Close();
            }

            result = result.Where(t=>Convert.ToInt32(t.Rate) > 10000).ToList();
            result.ForEach(t =>
            {
                t.Rate = Round(t.Rate);
                if(string.IsNullOrWhiteSpace(t.Comments))
                {
                    t.Comments = "...";
                }

                if(string.IsNullOrWhiteSpace(t.Title))
                {
                    t.Title = "...";
                }
            }
            );

            return result;
        }

        private static string Round(string rate)
        {
            return rate.Substring(0, rate.Length - 4) + "." + rate[rate.Length - 4] + "万";
        }

        private static string RemoveQuotes(string original)
        {
            if (string.IsNullOrWhiteSpace(original))
            {
                return string.Empty;
            }

            return original.Substring(1, original.Length - 2);
        }
    }
}