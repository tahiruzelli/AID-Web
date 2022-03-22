using AID;
using AID.Model;
using Microsoft.AspNetCore.Mvc;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class AnnouncementController : ControllerBase
    {
        private List<Announcement> _announcements = FakeData.getAnnouncements(200);
        [HttpGet("/GetAllAnnouncemets")]
        public ResponseModel<List<Announcement>> getAllAnnouncements()
        {
            ResponseModel<List<Announcement>> response = new ResponseModel<List<Announcement>>(true, _announcements, "");
            return response;
        }
    }
}
