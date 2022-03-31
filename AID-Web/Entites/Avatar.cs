using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AID.Entites
{
    public class Avatar
    {
        public int id { get; set; }
        public string avatarUrl { get; set; }
        public DateTime createTime { get; set; } = DateTime.UtcNow;

    }
}
