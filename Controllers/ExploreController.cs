using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YouTube.Models;
using YouTube.Models.Interfaces;

namespace YouTube.Controllers
{
   public class ExploreController : Controller
   {
      private readonly ILogger<ExploreController> _logger;
      private readonly Ivideo _video;
      public ExploreController(ILogger<ExploreController> logger, Ivideo video)
      {
         _logger = logger;
         _video = video;
      }

      public IActionResult Index()
      {
         return View();
      }
      public IActionResult Trending()
      {
         // List<video> trending = _video.GetAllTrendingVideos();
         return View();
      }
      public IActionResult Gaming()
      {
         // List<video> gaming = _video.getVideoByCatagory("Gaming");
         // return View(gaming);
         List<video> news = _video.getVideoByCatagory("News");
         return View(news);
      }
      public IActionResult News()
      {
         List<video> news = _video.getVideoByCatagory("News");
         return View(news);
      }

      [HttpPost]
      public JsonResult Search([FromBody] string query)
      {
         List<video> customers = _video.SearchVideos(query);
         Debug.WriteLine(query);
         return Json(customers);
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
