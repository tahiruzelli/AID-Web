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
        public User getUser(int id) {
            User user = _user.FirstOrDefault(x => x.id == id);
            return user;
        }
        [HttpGet("GetAllUsers")]
        public List<User> getAllUsers()
        {
            return _user;
        }
        [HttpPost("Login")]
        public bool login([FromBody]string email, [FromBody]string password)
        {
            User user = _user.FirstOrDefault(x => x.email == email);
            if (user == null) {
                return false;
            }
            else if (user.password == password)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
