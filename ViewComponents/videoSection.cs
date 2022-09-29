using Microsoft.AspNetCore.Mvc;
using YouTube.Models;
namespace YouTube.ViewComponents
{
   public class VideoSection : ViewComponent
   {
      public IViewComponentResult Invoke(string type, string name, string id)
      {
         video v = new video
         {
            Title = name,
            Url = id,
         };
         if (type.Equals("custom"))
         {
            return View("Custom", v);
         }
         return View("Default");
      }
   }
}
