using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YouTube.Models;
using YouTube.ViewModels;
using YouTube.Models.Interfaces;

namespace YouTube.Controllers
{
   public class HomeController : Controller
   {
      private readonly Ivideo _videos;
      private readonly IChannel _channel;
      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger, Ivideo video, IChannel channel)
      {
         _logger = logger;
         _videos = video;
         _channel = channel;
      }

      public IActionResult Index()
      {
         List<video> v = _videos.GetAllVideos();
         List<Channel> cList = new List<Channel>();
         List<VideoChannel> obj = new List<VideoChannel>();
         foreach (video vid in v)
         {
            Channel chanel = _channel.GetChannelByVideo(vid);
            obj.Add(new VideoChannel{v = vid , c = chanel});
         }
         return View(obj);
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
