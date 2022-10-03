namespace YouTube.Models
{
   public class Channel : AduitInfo
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      public string? Name { get; set; }
      public string? ProfileImg { get; set; }
      public int? Likes { get; set; }
      public int ViewsCount { get; set; }
      public string JoinDate { get; set; }
      public int Subscribers { get; set; }
      public virtual List<video> videos { get; set; }
      public virtual User User { get; set; }
      [ForeignKey("User")]
      public int userId { get; set; }
      public Channel()
      { }
   }
}
