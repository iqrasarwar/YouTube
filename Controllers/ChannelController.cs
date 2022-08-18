using Microsoft.AspNetCore.Mvc;
using YouTube.Models.Interfaces;
using YouTube.Models;
using Microsoft.VisualBasic.FileIO;

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
            HttpContext.Response.Cookies.Append("testreqdata", videoObj.Description);
            HttpContext.Request.Cookies.TryGetValue("email", out email);
            User thisUser = _user.GetUserByEmail(email);
            HttpContext.Response.Cookies.Append("gottenemail", thisUser.Email);
            Channel channel = _channel.GetChannelByUserId(thisUser.Id);
            if (channel == null)
            {
               _channel.AddChannel(new Models.Channel { userId = thisUser.Id, createdBy = thisUser.Username, createdAt = DateTime.Now, modifiedBy = "", modifiedAt = null, Name = thisUser.Username, JoinDate = DateTime.Now.ToString("dd/MM/yyyy") });
               channel = _channel.GetChannelByUserId(thisUser.Id);
            }
            string combianedUrl = renameAssets();
            _video.AddVideo(new Models.video
            {
               Title = videoObj.Title,
               Description = videoObj.Description,
               Catagory = videoObj.Catagory,
               Thumbnail = combianedUrl,
               ViewsCount = 0,
               TimeLine = DateTime.Now.ToString(),
               Likes = 0,
               channelId = channel.Id,
               Url = combianedUrl,
            });
            return new ObjectResult(new { status = "success" });
         }
         return new ObjectResult(new { status = "fail" });
      }
      private string renameAssets()
      {
         string thumbnailFolder = Path.Combine(this.Environment.WebRootPath, "uploadedthumbnails");
         string videosFolder = Path.Combine(this.Environment.WebRootPath, "uploadedVideos");
         string videoname = "", thumbnailname = "";
         HttpContext.Request.Cookies.TryGetValue("thisvideo", out videoname);
         HttpContext.Request.Cookies.TryGetValue("thisThumbnail", out thumbnailname);
         string newname = Guid.NewGuid().ToString();
         FileSystem.RenameFile(videosFolder + videoname, videosFolder + newname);
         FileSystem.RenameFile(thumbnailFolder + thumbnailname, thumbnailFolder + newname);
         return newname;
      }
   }
}
