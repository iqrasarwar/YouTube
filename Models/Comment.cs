namespace YouTube.Models
{
   public class Comment : AduitInfo
   {
      public int Id { get; set; }
      public User User { get; set; }
      public string? Description { get; set; }
      public int likesCount { get; set; }
      public string TimeLine { get; set; }
      public video video { get; set; }
      [ForeignKey("User")]
      public int userID { get; set; }
      [ForeignKey("video")]
      public int videoId { get; set; }
      public Comment()
      { }
   }
}
