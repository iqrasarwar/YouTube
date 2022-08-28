using Microsoft.AspNetCore.Mvc;
namespace YouTube.ViewComponents
{
   public class SideBarSection : ViewComponent
   {
      public IViewComponentResult Invoke(string SectionString)
      {
         if (SectionString == "partial")
         {
            return View("Partial");
         }
         else
         {
            return View("Default");
         }
      }
   }
}
