using Microsoft.AspNetCore.Mvc;
namespace YouTube.ViewComponents
{
   public class SideBarSection : ViewComponent
   {
      public IViewComponentResult Invoke(string SectionString)
      {

         if (SectionString == "first section")
         {
            return View("NavBarPartial", "rendered by view component");
         }
         else
         {
            return View("Default");
         }
      }
   }
}
