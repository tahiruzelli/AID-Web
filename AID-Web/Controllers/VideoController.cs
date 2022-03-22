using AID;
using AID.Model;
using Microsoft.AspNetCore.Mvc;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class VideoController : ControllerBase
    {
        private List<Video> _avatars = FakeData.getVideos(10);

        [HttpGet("GelAllVideos")]
        public ResponseModel<List<Video>> gelAllVideos()
        {
            return new ResponseModel<List<Video>>(true, _avatars, "");
        }
    }
}
