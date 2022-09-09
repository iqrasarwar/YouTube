using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YouTube.Models.Interfaces;
using YouTube.Models;

public class AppDbContext : IdentityDbContext
{
   public DbSet<video> myVideos { get; set; }
   public DbSet<Channel> channel { get; set; }
   public DbSet<User> user { get; set; }
   public DbSet<Comment> comments { get; set; }

   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
   { }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
   }
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YouTubeClone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
   }
   public override int SaveChanges()
   {
      var tracker = ChangeTracker;
      foreach (var entry in tracker.Entries())
      {
         if (entry.Entity is AduitInfo)
         {
            var referenceEntity = entry.Entity as AduitInfo;
            switch (entry.State)
            {
               case EntityState.Added:
                  referenceEntity.createdAt = DateTime.Now;
                  referenceEntity.modifiedAt = null;
                  referenceEntity.modifiedBy = null;
                  break;
               case EntityState.Deleted:
               case EntityState.Modified:
                  referenceEntity.modifiedAt = DateTime.Now;
                  break;
               default:
                  break;
            }
         }
      }
      return base.SaveChanges();
   }

}
