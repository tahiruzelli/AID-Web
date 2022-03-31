﻿using AID;
using AID.Data;
using AID.Entites;
using AID_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VideoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllVideos")]
        public async  Task<ResponseModel<List<Video>>> gelAllVideos()
        {
            List<Video> _avatars = await _context.Videos.ToListAsync();
            return new ResponseModel<List<Video>>(true, _avatars, "");
        }
        [HttpPost("CreateVideo")]
        public async Task<ResponseModel<Video>> CreateVideo([FromBody] CreateVideoModel newVideo)
        {
            Video video = new Video();
            video.videoUrl = newVideo.videoUrl;
            video.videoLength= newVideo.videoLength;
            video.coverImageUrl = newVideo.coverImageUrl;
            video.createTime = DateTime.UtcNow;
            _context.Add(video);
            _context.SaveChanges();
            return new ResponseModel<Video>(true, video, "");
        }
    }
}