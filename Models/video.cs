namespace YouTube.Models
{
   public class video : AduitInfo
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [ForeignKey("Channel")]
      public int Id { get; set; }
      public string? Title { get; set; }
      public string? Description { get; set; }
      public string? Url { get; set; }
      public string? Thumbnail { get; set; }
      public int ViewsCount { get; set; }
      public string TimeLine { get; set; }
      public string Catagory { get; set; }
      public int Likes { get; set; }
      public virtual Channel channel { get; set; }
      public virtual List<Comment> comments { get; set; }
      public video()
      { }
   }
}
