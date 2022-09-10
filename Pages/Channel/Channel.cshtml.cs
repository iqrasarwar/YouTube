// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc;
// using System.ComponentModel.DataAnnotations;
// using System.Diagnostics;
// namespace YouTube.Pages
// {
//    public class Channel : PageModel
//    {
//       private readonly IWebHostEnvironment Environment;

//       public Channel(IWebHostEnvironment Environment)
//       {
//          this.Environment = Environment;
//       }
//       public IActionResult OnPost(IFormFile video)
//       {
//          Debug.Write(video.FileName);
//          if (video != null)
//          {
//             string videosFolder = Path.Combine(this.Environment.WebRootPath, "uploadedVideos");
//             if(!Directory.Exists(videosFolder))
//             {
//                Directory.CreateDirectory(videosFolder);
//             }
//             string filePath = Path.Combine(videosFolder, video.FileName);
//             using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
//             {
//                video.CopyTo(fileStream);
//             }
//             return new ObjectResult(new { status = "success" });
//          }
//          return new ObjectResult(new { status = "fail" });

//       }
//    }
// }
