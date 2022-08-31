using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YouTube.Models;

namespace YouTube.Controllers
{
   public class VideoController : Controller
   {
      private readonly ILogger<VideoController> _logger;

      public VideoController(ILogger<VideoController> logger)
      {
         _logger = logger;
      }

      public IActionResult Index()
      {
         return View();
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
