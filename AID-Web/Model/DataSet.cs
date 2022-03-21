using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AID.Model
{
    public class DataSet
    {
        public int id { get; set; }
        public string photoUrl { get; set; }
        public int tagId { get; set; }
        public int userId { get; set; }
        public DateTime createTime { get; set; }
    }
}
