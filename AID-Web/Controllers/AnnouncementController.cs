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
        public ResponseModel getAllAnnouncements()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result["announcements"] = _announcements;
            ResponseModel response = new ResponseModel(true, result, "");
            return response;
        }
    }
}
