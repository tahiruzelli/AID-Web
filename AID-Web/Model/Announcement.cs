using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AID.Model
{
    public class Announcement
    {
        public int id { get; set; }
        public string photoUrl { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime createTime { get; set; }

    }
}
