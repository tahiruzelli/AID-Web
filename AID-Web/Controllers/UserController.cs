using AID.Data;
using AID.Entites;
using AID_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AID.Controller
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("GetUser/{id}")]
        public async Task<ResponseModel<User>> GetUser(int id) {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.id == id);
            if (user is null)
                return new ResponseModel<User>(false, null, "Böyle bir user yok");

            return new ResponseModel<User>(true, user, "");

        }
        [HttpGet("GetAllUsers")]
        public async Task<ResponseModel<List<User>>> GetAllUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            return new ResponseModel<List<User>>(true, users, "");
        }
        [HttpPost("Login")]
        public async Task<ResponseModel<User>> Login([FromBody]LoginModel loginUser)
        {

            List<User> user = await _context.Users.Where(x => x.email == loginUser.email).ToListAsync();
            if (!user.Any())
            {
                return new ResponseModel<User>(false, null, "Bu emaile ait bir user yok!");
            }
            else if (user.Count > 1) {
                return new ResponseModel<User>(false, null, "Bu emaile kayıtlı birden fazla kullanıcı var!");
            }
            else if (user[0].password == loginUser.password)
            {
                return new ResponseModel<User>(true, user[0], "");
            }
            else
            {
                return new ResponseModel<User>(false, null, "Parola eşleşmiyor");
            }

        }
        [HttpPost("Register")]
        public async Task<ResponseModel<User>> Register([FromBody]RegisterModel newUser)
        {
            var user2 = await _context.Users.Where(x => x.email == newUser.email).ToListAsync();
            if (user2.Any())
            {
                return new ResponseModel<User>(false, null, "Email zaten kayıtlı!");
            }
            User user = new User();
            user.email = newUser.email;
            user.password = newUser.password;
            user.avatarId = newUser.avatarId;
            user.name = newUser.name;
            user.totalGain = 0;
            user.balance = 0;
            user.totalVideoEditetTime = 0;
            _context.Add(user);
            _context.SaveChanges();
            return new ResponseModel<User>(true,user,"");
        }
    }
}
