using Microsoft.AspNetCore.Mvc;
namespace YouTube.ViewComponents
{
   public class VideoSection : ViewComponent
   {
      public IViewComponentResult Invoke()
      {
         return View("Default");
      }
   }
}
