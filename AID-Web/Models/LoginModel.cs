using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AID_Web.Models
{
    public class LoginModel
    {
        public string email { get; set; }
        public string password { get; set; }

    }
}
