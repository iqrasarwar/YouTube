namespace YouTube.Models
{
   public class User : AduitInfo
   {
      [Key]
      public int Id { get; set; }
      [Required]
      [StringLength(20, ErrorMessage = "Length should not exceed 20 characters")]
      public string? Username { get; set; }
      [Required]
      [EmailAddress]
      public string? Email { get; set; }
      public string ProfileImg { get; set; }
      [ForeignKey("Channel")]
      public int channelId { get; set; }
      public Channel Channel { get; set; }
      public List<Comment> comments { get; set; }
      public User()
      { }
   }
}
