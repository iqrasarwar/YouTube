using Microsoft.AspNetCore.Mvc;
namespace YouTube.ViewComponents
{
   public class commentsSection : ViewComponent
   {
      public IViewComponentResult Invoke()
      {
         return View("Default");
      }
   }
}
