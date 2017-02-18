using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Biz.DataCenter
{
    public class HealthCache
    {
        public static DateTime LastHeartBeatTime = DateTime.UtcNow.AddHours(8);
    }
}