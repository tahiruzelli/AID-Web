using AID;
using AID.Data;
using AID.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TagController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAllTags")]
        public async Task<ResponseModel<List<Tag>>> GetAllTags()
        {
            List<Tag> _tags = await _context.Tags.ToListAsync();
            return new ResponseModel<List<Tag>>(true, _tags, "");
        }

        [HttpGet("CreateTag/{name}")]
        public async Task<ResponseModel<Tag>> CreateTag(string name) {
            Tag newTag = new Tag();
            newTag.name = name;
            newTag.createTime = DateTime.UtcNow;
            _context.Add(newTag);
            _context.SaveChanges();
            return new ResponseModel<Tag>(true, newTag, "");
        }

    }
}
