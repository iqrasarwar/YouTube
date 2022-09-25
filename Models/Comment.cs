namespace YouTube.Models
{
   public class Comment : AduitInfo
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      public virtual User User { get; set; }
      public string? Description { get; set; }
      public int likesCount { get; set; }
      public string TimeLine { get; set; }
      public virtual video video { get; set; }
      public Comment()
      { }
   }
}
