using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AID.Entites
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int avatarId { get; set; }
        public double balance { get; set; }
        public double totalGain { get; set; }
        public double totalVideoEditetTime { get; set; }
        public DateTime createDate { get; set; } = DateTime.UtcNow;




    }
}
