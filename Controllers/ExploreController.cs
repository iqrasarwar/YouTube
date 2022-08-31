using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YouTube.Models;
using YouTube.Models.Interfaces;
using YouTube.Models.Repositries;

namespace YouTube.Controllers
{
   public class ExploreController : Controller
   {
      private readonly ILogger<ExploreController> _logger;
      private readonly IExplore<video> _explore;
      public ExploreController(ILogger<ExploreController> logger, IExplore<video> explore)
      {
         _logger = logger;
         _explore = explore;
      }

      public IActionResult Index()
      {
         return View();
      }
      public IActionResult Trending()
      {
         List<video> trending = _explore.GetAllTrendingVideos();
         return View(trending);
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
