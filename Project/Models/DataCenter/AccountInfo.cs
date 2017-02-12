using System.Collections.Generic;

namespace Project.Models
{
    public class AccountInfo
    {
        public string Link { get; set; }

        public string Title { get; set; }

        public double Fee { get; set; }
        public double Value { get; set; }

        public int SRRCount { get; set; }

        public int Level { get; set; }

        public List<SSR> SSRList {get;set;}

        public int Star { get; set; }
    }
}