using Microsoft.AspNetCore.Mvc;
using YouTube.Models.Interfaces;
using YouTube.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace YouTube.Controllers
{
   public class ChannelController : Controller
   {
      private readonly IWebHostEnvironment Environment;
      private readonly ILogger<HomeController> _logger;
      private readonly IUser _user;
      private readonly Ivideo _video;
      private readonly IChannel _channel;
      public ChannelController(IWebHostEnvironment Environment, ILogger<HomeController> logger, IUser user, IChannel channel, Ivideo video)
      {
         _user = user;
         _channel = channel;
         _video = video;
         _logger = logger;
         this.Environment = Environment;
      }
      public IActionResult Index()
      {
         return View();
      }
      [HttpPost]
      public IActionResult Index(IFormFile video)
      {
         if (video != null)
         {
            string videosFolder = Path.Combine(this.Environment.WebRootPath, "uploadedVideos");
            if (!Directory.Exists(videosFolder))
            {
               Directory.CreateDirectory(videosFolder);
            }
            if (!HttpContext.Request.Cookies.ContainsKey("thisvideo"))
               HttpContext.Response.Cookies.Append("thisvideo", video.FileName);
            else
            {
               HttpContext.Response.Cookies.Delete("thisvideo");
               HttpContext.Response.Cookies.Append("thisvideo", video.FileName);
            }
            string filePath = Path.Combine(videosFolder, video.FileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
               video.CopyTo(fileStream);
            }
            return new ObjectResult(new { status = "success" });
         }
         return new ObjectResult(new { status = "fail" });

      }
      [HttpGet]
      public IActionResult Upload()
      {
         return View();
      }
      [HttpPost]
      public IActionResult Upload(IFormFile thumbnail)
      {
         if (thumbnail != null)
         {
            string thumbnailFolder = Path.Combine(this.Environment.WebRootPath, "uploadedthumbnails");
            if (!Directory.Exists(thumbnailFolder))
            {
               Directory.CreateDirectory(thumbnailFolder);
            }
            if (!HttpContext.Request.Cookies.ContainsKey("thisThumbnail"))
               HttpContext.Response.Cookies.Append("thisThumbnail", thumbnail.FileName);
            else
            {
               HttpContext.Response.Cookies.Delete("thisThumbnail");
               HttpContext.Response.Cookies.Append("thisThumbnail", thumbnail.FileName);
            }
            string filePath = Path.Combine(thumbnailFolder, thumbnail.FileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
               thumbnail.CopyTo(fileStream);
            }
            return new ObjectResult(new { status = "success" });
         }
         return new ObjectResult(new { status = "fail" });
      }
      [HttpPost]
      public IActionResult UploadData([FromBody] video videoObj)
      {
         if (videoObj != null)
         {
            string email = "";
            HttpContext.Request.Cookies.TryGetValue("email", out email);
            User thisUser = _user.GetUserByEmail(email);
            Channel channel = _channel.GetChannelByUserId(thisUser.Id);
            if (channel == null)
            {
               _channel.AddChannel(new Models.Channel { userId = thisUser.Id, createdBy = thisUser.Username, createdAt = DateTime.Now, modifiedBy = "", modifiedAt = null, Name = thisUser.Username, JoinDate = DateTime.Now.ToString("dd/MM/yyyy") });
               channel = _channel.GetChannelByUserId(thisUser.Id);
            }
            string videourl = renameAssets(out string thumbanilurl);
            _video.AddVideo(new Models.video
            {
               Title = videoObj.Title,
               Description = videoObj.Description,
               Catagory = videoObj.Catagory,
               Thumbnail = thumbanilurl,
               ViewsCount = 0,
               TimeLine = DateTime.Now.ToString(),
               Likes = 0,
               channelId = channel.Id,
               Url = videourl,
               createdAt = DateTime.Now,
               createdBy = thisUser.Username,
               modifiedAt = null,
               modifiedBy = null
            });
            return new ObjectResult(new { status = "success" });
         }
         return new ObjectResult(new { status = "fail" });
      }
      private string renameAssets(out string tname)
      {
         string thumbnailFolder = Path.Combine(this.Environment.WebRootPath, "uploadedthumbnails");
         string videosFolder = Path.Combine(this.Environment.WebRootPath, "uploadedVideos");
         string videoname = "", thumbnailname = "";
         HttpContext.Request.Cookies.TryGetValue("thisvideo", out videoname);
         HttpContext.Request.Cookies.TryGetValue("thisThumbnail", out thumbnailname);
         string newname = Guid.NewGuid().ToString();
         string oldvideopath = Path.Combine(videosFolder, videoname);
         string oldthumbnailpath = Path.Combine(thumbnailFolder, thumbnailname);
         string videoExt = videoname.Split(".").Last();
         string thumnailExt = thumbnailname.Split(".").Last();
         string newvideoname = newname + "." + videoExt;
         string newThumbnailname = newname + "." + thumnailExt;
         FileSystem.RenameFile(oldvideopath, newvideoname);
         FileSystem.RenameFile(oldthumbnailpath, newThumbnailname);
         tname = newThumbnailname;
         return newvideoname;
      }
   }
}
