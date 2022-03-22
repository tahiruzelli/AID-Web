using AID.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AID.Controller
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private List<User> _user = FakeData.getUsers(200);
        [HttpGet("GetUser/{id}")]
        public ResponseModel<User> getUser(int id) {
            User user = _user.FirstOrDefault(x => x.id == id);
            if (user == null) {
                return new ResponseModel<User>(false, null, "Böyle bir user yok");
            }
            else
            {
                return new ResponseModel<User>(true, user, "");
            }
            
        }
        [HttpGet("GetAllUsers")]
        public ResponseModel<List<User>> getAllUsers()
        {
            return new ResponseModel<List<User>>(true, _user, "");
        }
        [HttpPost("Login")]
        public ResponseModel<User> login([FromBody]string email, [FromBody]string password)
        {
            User user = _user.FirstOrDefault(x => x.email == email);
            if (user == null) {
                return new ResponseModel<User>(false, null, "Bu emaile ait bir user yok!");
            }
            else if (user.password == password)
            {
                return new ResponseModel<User>(true, user, "");
            }
            else
            {
                return new ResponseModel<User>(false, null, "Parola eşleşmiyor");
            }

        }
        [HttpPost("Register")]
        public ResponseModel<User> register([FromBody] string email, [FromBody] string password, [FromBody] string name, [FromBody] int avatarId)
        {
            User user = new User();
            user.id = 0;
            user.name = name;
            user.email = email;
            user.avatarId = avatarId;
            user.password = password;
            user.totalGain = 0;
            user.balance = 0;
            user.totalVideoEditetTime = 0;
            user.createDate = DateTime.Now;
            _user.Add(user);
             return new ResponseModel<User>(true,user,"");
        }
    }
}
