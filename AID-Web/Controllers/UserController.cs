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
        public ResponseModel getUser(int id) {
            User user = _user.FirstOrDefault(x => x.id == id);
            if (user == null) {
                ResponseModel response = new ResponseModel(false, null, "Böyle bir user yok");
                return response;
            }
            else
            {
                Dictionary<string, object> selectedUser = new Dictionary<string, object>();
                selectedUser["user"] = user;
                ResponseModel response = new ResponseModel(true, selectedUser, "");
                return response;
            }
            
        }
        [HttpGet("GetAllUsers")]
        public ResponseModel getAllUsers()
        {
            Dictionary<string, object> allUsers = new Dictionary<string, object>();
            allUsers["users"] = _user;
            ResponseModel response = new ResponseModel(true, allUsers, "");
            return response;
        }
        [HttpPost("Login")]
        public ResponseModel login([FromBody]string email, [FromBody]string password)
        {
            User user = _user.FirstOrDefault(x => x.email == email);
            ResponseModel response;


            if (user == null) {
                response = new ResponseModel(false, null, "Bu emaile ait bir user yok!");
                return response;
            }
            else if (user.password == password)
            {
                Dictionary<string, object> selectedUser = new Dictionary<string, object>();
                selectedUser["user"] = user;
                response = new ResponseModel(true, selectedUser, "");
                return response;
            }
            else
            {
                response = new ResponseModel(false, null, "Parola eşleşmiyor");
                return response;
            }

        }
        [HttpPost("Register")]
        public ResponseModel register([FromBody] string email, [FromBody] string password, [FromBody] string name, [FromBody] int avatarId)
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
            Dictionary<string, object> newUser = new Dictionary<string, object>();
            newUser["users"] = user;
            ResponseModel response = new ResponseModel(true,newUser,"");
            return response;
        }
    }
}
