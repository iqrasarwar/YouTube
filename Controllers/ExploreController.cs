using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YouTube.Models;

namespace YouTube.Controllers
{
   public class ExploreController : Controller
   {
      private readonly ILogger<ExploreController> _logger;
      public ExploreController(ILogger<ExploreController> logger)
      {
         _logger = logger;
      }

      public IActionResult Index()
      {
         return View();
      }
      public IActionResult Trending()
      {
         // List<video> trending = _explore.GetAllTrendingVideos();
         return View();
      }
      public IActionResult Gaming()
      {
         return View();
      }
      public IActionResult Music()
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
