namespace YouTube.Models.Interfaces
{
   public interface Ivideo
   {
      public List<video> GetAllVideos();
      public List<video> GetVideoById(int id);
      public void AddVideo(video video);
      public void UpdateVideo(video video);
      public void DeleteVideo(int id);
      public List<video> getVideoByCatagory(string catagory);
      public List<video> getVideoByChannel(int channelId);
   }
}
