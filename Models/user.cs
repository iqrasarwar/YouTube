namespace YouTube.Models
{
   public class User : AduitInfo
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      [Required]
      [StringLength(20, ErrorMessage = "Length should not exceed 20 characters")]
      public string Username { get; set; }
      [Required]
      public string Email { get; set; }
      public string? ProfileImg { get; set; }
      public virtual Channel Channel { get; set; }
      public virtual List<Comment> comments { get; set; }
      public User()
      { }
   }
}
