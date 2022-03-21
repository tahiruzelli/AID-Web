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

    }
}
