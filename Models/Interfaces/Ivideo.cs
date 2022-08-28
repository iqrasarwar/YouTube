namespace YouTube.Models.Interfaces
{
    public interface Ivideo
    {
         public List<video> GetAllVideos();
         public video GetVideoById(int id);
         public void AddVideo(video video);
         public void UpdateVideo(video video);
         public void DeleteVideo(int id);
    }
}
