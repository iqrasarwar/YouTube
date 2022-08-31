using YouTube.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace YouTube.Models.Repositries
{
   public class IvideoRepositry<video> : Ivideo<video> where video : class
   {
      private readonly AppDbContext _appDbContext;
      private DbSet<video> _videos;
      public IvideoRepositry(AppDbContext appDbContext)
      {
         _appDbContext = appDbContext;
         _videos = _appDbContext.Set<video>();
      }
      public video GetVideoById(int id)
      {
         return null;
         // return _videos.Find(id);
      }
      public void AddVideo(video video)
      {
         _videos.Add(video);
         _appDbContext.SaveChanges();
      }
      public void UpdateVideo(video video)
      {
         _videos.Update(video);
         _appDbContext.SaveChanges();
      }
      public void DeleteVideo(int id)
      {
         var video = _videos.Find(id);
         _videos.Remove(video);
         _appDbContext.SaveChanges();
      }
      public IEnumerable<video> GetAllVideos()
      {
         return _videos.ToList();
      }

   }
}
