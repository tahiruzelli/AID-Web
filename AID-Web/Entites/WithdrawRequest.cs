using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AID.Entites
{
    public class WithdrawRequest
    {
        public int id { get; set; }
        public double balance { get; set; }
        public string cardNo { get; set; }
        public int cvv { get; set; }
        public string expDate { get; set; }
        public string cardHolder { get; set; }
        public int userId { get; set; }
        public DateTime createTime { get; set; } = DateTime.UtcNow;
        public bool isApproved { get; set; }
    }
}
