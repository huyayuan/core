using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models.DataCenter
{
    public class HealthCheckDto
    {
        public string LastHeartBeatTime { get; set; }
        public string LastEmailSentTime { get; set; }
    }
}