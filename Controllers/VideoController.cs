using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YouTube.Models;
using YouTube.Models.Interfaces;

namespace YouTube.Controllers
{
   public class VideoController : Controller
   {
      private readonly ILogger<VideoController> _logger;
      private readonly Ivideo _videos;

      public VideoController(ILogger<VideoController> logger, Ivideo video)
      {
         _logger = logger;
         _videos = video;
      }

      public IActionResult Index(string id)
      {
         return View();
      }

      public IActionResult Video(string id)
      {
         video v = _videos.GetVideoByUrl(id);
         return View("Video", v);
      }
      public IActionResult AddVideo()
      {
         return View();
      }
      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
