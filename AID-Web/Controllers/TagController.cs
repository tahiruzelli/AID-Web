using AID;
using AID.Model;
using Microsoft.AspNetCore.Mvc;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class TagController : ControllerBase
    {
        private List<Tag> _tags = FakeData.getTags(10);
        [HttpGet("GetAllTags")]
        public ResponseModel<List<Tag>> getAllTags()
        {
            return new ResponseModel<List<Tag>>(true, _tags, "");
        }

    }
}
