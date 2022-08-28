namespace YouTube.Models
{
   public class video : AduitInfo
   {
      public int? Id { get; set; }
      public string? Title { get; set; }
      public string? Description { get; set; }
      public string? Url { get; set; }
      public string? Thumbnail { get; set; }
   }
}
