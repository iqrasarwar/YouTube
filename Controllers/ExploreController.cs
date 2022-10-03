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
         List<video> trending = _video.GetAllVideos();
         return View(trending);
      }
      public IActionResult Sports()
      {
         List<video> sports = _video.getVideoByCatagory("Sports");
         return View(sports);
      }
      public IActionResult Gaming()
      {
         List<video> gaming = _video.getVideoByCatagory("Gaming");
         return View(gaming);
      }
      public IActionResult Music()
      {
         List<video> music = _video.getVideoByCatagory("Music");
         return View(music);
      }
      public IActionResult News()
      {
         List<video> news = _video.getVideoByCatagory("News");
         return View(news);
      }

      [HttpPost]
      public JsonResult Search([FromBody] Object query)
      {
         List<video> videosReturned = _video.SearchVideos(query.ToString());
         Debug.WriteLine(query);
         return Json(videosReturned);
      }
      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
