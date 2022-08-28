// using Microsoft.AspNetCore.Mvc;
// using Google.Apis.YouTube.v3;
// namespace YouTube.ViewComponents
// {
//    public class api
//    {
//       public static List<YouTubeVideo> Videos { get; private set; } = new List<YouTubeVideo>();

//       private readonly YouTubeService youTubeService;

//       public api(YouTubeService youTubeService)
//       {
//          this.youTubeService = youTubeService;
//       }
//       public async Task onGet()
//       {
//          var searchListRequest = youTubeService.Videos.List("snippet,contentDetails,statistics");
//          searchListRequest.Chart = VideosResource.ListRequest.ChartEnum.MostPopular;
//          searchListRequest.RegionCode = "pk";
//          var searchListResponse = await searchListRequest.ExecuteAsync();
//          Videos.AddRange(searchListResponse.Items.Select(video => new YouTubeVideo
//          {
//             Thumbnail = video.Snippet.Thumbnails.High.Url,
//             Title = video.Snippet.Title,
//             VideoId = video.Id,
//             channelName = video.Snippet.ChannelTitle,
//             viewsCount = video.Statistics.ViewCount,
//             date = video.FileDetails.CreationTime,
//          }));
//       }
//    }
// }
// public class YouTubeVideo
// {
//    public string Thumbnail { get; internal set; }
//    public string Title { get; internal set; }
//    public string VideoId { get; internal set; }
//    public string channelName { get; internal set; }
//    public ulong? viewsCount { get; internal set; }
//    public string date { get; internal set; }
// }
