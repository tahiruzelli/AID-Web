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
        public ResponseModel<List<Avatar>> getAllAvatars()
        {
            
            return new ResponseModel<List<Avatar> >(true, _avatars, "");
        }
    }
}
