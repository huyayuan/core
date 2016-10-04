using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Biz
{
    public static class DataCache
    {
        public static Dictionary<int, List<Box>> Data = new Dictionary<int, List<Box>>();
    }
}