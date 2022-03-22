using AID;
using AID.Model;
using Microsoft.AspNetCore.Mvc;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class AvatarController : ControllerBase
    {
        private List<Avatar> _avatars = FakeData.getAvatars(10);
        [HttpGet("GelAllAvatars")]
        public ResponseModel getAllAvatars()
        {
            Dictionary<string, object> avatars = new Dictionary<string, object>();
            avatars["avatars"] = _avatars;
            ResponseModel response = new ResponseModel(true, avatars, "");
            return response;
        }
    }
}
