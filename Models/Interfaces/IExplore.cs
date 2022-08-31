namespace YouTube.Models.Interfaces
{
   public interface IExplore<video> where video : class
   {
      List<video> GetAllTrendingVideos();
   }
}
