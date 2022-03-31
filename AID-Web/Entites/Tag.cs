using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AID.Entites
{
    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createTime { get; set; } = DateTime.UtcNow;

    }
}
