using AID;
using AID.Data;
using AID.Entites;
using AID_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class AnnouncementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllAnnouncemets")]
        public async Task<ResponseModel<List<Announcement>>> getAllAnnouncements()
        {
            List<Announcement> announcement = await _context.Announcements.ToListAsync();
            ResponseModel<List<Announcement>> response = new ResponseModel<List<Announcement>>(true, announcement, "");
            return response;
        }
        [HttpPost("CreateAnnouncement")]
        public async Task<ResponseModel<Announcement>> CreateAnnouncement([FromBody] CreateAnnouncementModel newAnnouncement)
        {
            Announcement announcement = new Announcement();
            announcement.title = newAnnouncement.title;
            announcement.description = newAnnouncement.description;
            announcement.photoUrl = newAnnouncement.photoUrl;
            announcement.createTime = DateTime.UtcNow;
            _context.Add(announcement);
            _context.SaveChanges();
            return new ResponseModel<Announcement>(true, announcement, "");
        }
    }
}
