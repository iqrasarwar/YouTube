using YouTube.Models.Interfaces;

namespace YouTube.Models.Repositries
{
   public class IvideoRepositry : Ivideo
   {
      private readonly AppDbContext _appDbContext;
      public IvideoRepositry(AppDbContext appDbContext)
      {
         _appDbContext = appDbContext;
      }
      public List<video> GetVideoById(int id)
      {
         return _appDbContext.myVideos.Where(video => video.Id == id).ToList();
      }
      public void AddVideo(video video)
      {
         _appDbContext.myVideos.Add(video);
         _appDbContext.SaveChanges();
      }
      public void UpdateVideo(video video)
      {
         _appDbContext.myVideos.Update(video);
         _appDbContext.SaveChanges();
      }
      public void DeleteVideo(int id)
      {
         var video = _appDbContext.myVideos.Find(id);
         _appDbContext.myVideos.Remove(video);
         _appDbContext.SaveChanges();
      }
      public List<video> GetAllVideos()
      {
         return _appDbContext.myVideos.ToList();
      }
      public List<video> getVideoByCatagory(string catagory)
      {
         return _appDbContext.myVideos.Where(video => video.Catagory == catagory).ToList();
      }
      public List<video> getVideoByChannel(int channelId)
      {
         return _appDbContext.myVideos.Where(video => video.channel.Id == channelId).ToList();
      }
   }
}
