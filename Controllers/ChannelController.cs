using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace YouTube.Controllers
{
   public class ChannelController : Controller
   {
      private readonly IWebHostEnvironment Environment;
      private readonly ILogger<HomeController> _logger;
      public ChannelController(IWebHostEnvironment Environment, ILogger<HomeController> logger)
      {
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
         Debug.Write(video.FileName);
         if (video != null)
         {
            string videosFolder = Path.Combine(this.Environment.WebRootPath, "uploadedVideos");
            if (!Directory.Exists(videosFolder))
            {
               Directory.CreateDirectory(videosFolder);
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
      // [HttpPost]
      // public IActionResult Upload()
      // {
      //    return View();
      // }0
   }
}
