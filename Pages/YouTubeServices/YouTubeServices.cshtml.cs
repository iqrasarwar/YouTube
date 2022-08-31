using System;
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
         foreach (var item in searchListResponse.Items)
         {
            System.Diagnostics.Debug.WriteLine("high height" + item.Snippet.Thumbnails.High.Height);
            System.Diagnostics.Debug.WriteLine("high width" + item.Snippet.Thumbnails.High.Width);
            System.Diagnostics.Debug.WriteLine("medium height" + item.Snippet.Thumbnails.Medium.Height);
            System.Diagnostics.Debug.WriteLine("medium width" + item.Snippet.Thumbnails.Medium.Width);
            System.Diagnostics.Debug.WriteLine("starndard height" + item.Snippet.Thumbnails.High.Height);
            System.Diagnostics.Debug.WriteLine("standard width" + item.Snippet.Thumbnails.High.Width);

         }
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
   public string? Thumbnail { get; internal set; }
   public string? Title { get; internal set; }
   public string? VideoId { get; internal set; }
}
