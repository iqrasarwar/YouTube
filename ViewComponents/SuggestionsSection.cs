using Microsoft.AspNetCore.Mvc;
namespace YouTube.ViewComponents
{
   public class SuggestionsSection : ViewComponent
   {
      public IViewComponentResult Invoke()
      {
         return View("Default");
      }
   }
}
