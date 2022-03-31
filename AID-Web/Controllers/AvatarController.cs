using AID;
using AID.Data;
using AID.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class AvatarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AvatarController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GelAllAvatars")]
        public async Task<ResponseModel<List<Avatar>>> getAllAvatars()
        {
            List<Avatar> avatars = await _context.Avatars.ToListAsync();
            Console.WriteLine(avatars);
            return new ResponseModel<List<Avatar>>(true, avatars, "");
        }
        [HttpGet("CreateAvatar/{url}")]
        public async Task<ResponseModel<Avatar>> CreateAvatar(string url)
        {
            Avatar newAvatar = new Avatar();
            newAvatar.avatarUrl = HttpUtility.UrlDecode(url);
            newAvatar.createTime = DateTime.UtcNow;
            _context.Add(newAvatar);
            _context.SaveChanges();
            return new ResponseModel<Avatar>(true, newAvatar, "");
        }
    }
}
