namespace YouTube.Models
{
   public class Channel : AduitInfo
   {
      [Key]
      public int Id { get; set; }
      public string? Name { get; set; }
      public string? ProfileImg { get; set; }
      public int? Likes { get; set; }
      public int ViewsCount { get; set; }
      public string JoinDate { get; set; }
      public int Subscribers { get; set; }
      public List<video> videos { get; set; }
      public int userId { get; set; }
      public User User { get; set; }
      public Channel()
      { }
   }
}
