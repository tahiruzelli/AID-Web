using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AID.Entites
{
    public class Video
    {
        public int id { get; set; }
        public string videoUrl { get; set; }
        public double videoLength { get; set; }
        public double totalGain { get; set; }
        public string coverImageUrl { get; set; }
        public DateTime createTime { get; set; } = DateTime.UtcNow;
        public bool isActive { get; set; }

    }
}
