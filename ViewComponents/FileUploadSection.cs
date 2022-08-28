using Microsoft.AspNetCore.Mvc;
namespace YouTube.ViewComponents
{
   public class FileUploadSection : ViewComponent
   {
      public IViewComponentResult Invoke()
      {
         return View("Default");
      }
   }
}
