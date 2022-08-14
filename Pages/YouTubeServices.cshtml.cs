using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YouTube.Pages
{
   public class YouTubeServices : PageModel
   {
      public List<YouTubeVideo> Videos { get; private set; } = new List<YouTubeVideo>();

      private readonly YouTubeService youTubeService;

      public YouTubeServices(YouTubeService youTubeService)
      {
         this.youTubeService = youTubeService;
      }

      public async Task OnGet()
      {
         var searchListRequest = youTubeService.Videos.List("snippet,contentDetails,statistics");
         searchListRequest.Chart = VideosResource.ListRequest.ChartEnum.MostPopular;
         searchListRequest.RegionCode = "pk";

         var searchListResponse = await searchListRequest.ExecuteAsync();
         Videos.AddRange(searchListResponse.Items.Select(video => new YouTubeVideo
         {
            Thumbnail = video.Snippet.Thumbnails.High.Url,
            Title = video.Snippet.Title,
            VideoId = video.Id,
         }));
      }
   }
}

public class YouTubeVideo
{
   public string Thumbnail { get; internal set; }
   public string Title { get; internal set; }
   public string VideoId { get; internal set; }
}
